using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : MonoBehaviour
{
    #region Variables
    [SerializeField] private BallastTank MainBallast;
    [SerializeField] private BallastTank _BackBallast;//Having two ballast tanks does not currently work
    [SerializeField] private Propeller L_Screw;
    [SerializeField] private Propeller R_Screw;
    [SerializeField] private Propeller Main_Screw;
    [SerializeField] private Rigidbody _Rb;
    [SerializeField] private AnimationCurve WaterTension;
    [HideInInspector] public float _CurrentForce;
    private bool _Neutral;
    private bool _Diving;
    #endregion Variables

    private void Awake()
    {
        _Rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//Neutral Buoyancy (toggle on to stay neutral or off to surface)
        {
            if (!_Neutral) _Neutral = true;
            else _Neutral = false;
        }
        if (Input.GetKey(KeyCode.LeftShift))//Posiitve Buoyancy 
        {
            if (!_Diving) _Diving = true;
            if (_Neutral) _Neutral = false;
        }
        else _Diving = false;
    }

    private void FixedUpdate()
    {           
        #region PropellerInput
        //Forward and Back
        if (Input.GetAxis("Vertical") != 0)
        {
            Main_Screw.SetThrust(Input.GetAxis("Vertical"));
        }
        //Left
        if (Input.GetAxis("Horizontal") < 0)
        {
            L_Screw.SetThrust(Mathf.Abs(Input.GetAxis("Horizontal")));
        }
        //Right
        if (Input.GetAxis("Horizontal") > 0)
        {
            R_Screw.SetThrust(Input.GetAxis("Horizontal"));
        }
        #endregion PropellerInput

        #region Buoyancy
        if (_Neutral) //F=G
        {
            float F = _Rb.velocity.y;
            _CurrentForce = F;
            if (MainBallast != null) MainBallast.ApplyBuoyancy(-F);
        }
        if (!_Neutral)
        {
            if (transform.position.y < 0)//Natural buoyancy
            {
                float F = 0.5f;
                _CurrentForce = 1;
                if (MainBallast != null) { MainBallast.ApplyBuoyancy(F); }
            }
            if (transform.position.y > 0)//Surface tension when leaving water
            {
                float w = _Rb.velocity.y * WaterTension.Evaluate(Time.deltaTime * 0.01f);
                _Rb.velocity = new Vector3(_Rb.velocity.x, w, _Rb.velocity.z);
            }
        }
        if (_Diving)//Positve Buoyancy 
        {
            float F = -0.5f;
            _CurrentForce = -1;
            if (MainBallast != null) MainBallast.ApplyBuoyancy(F);
        }
        #endregion Buoyancy

    }
}
