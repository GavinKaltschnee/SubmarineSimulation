using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallastTank : MonoBehaviour
{
    #region Variables
    [SerializeField] private float Speed = 1f;
    [SerializeField] private float Density = 450f;
    [SerializeField] private float DampeningFactor = 0.1f;
    [SerializeField] private Transform Water;
    private Rigidbody _Rb;
    private Transform _SubPos;
    private Vector3 _Archimedes;
    #endregion Variables

    private void Start()
    {
        _Rb = GetComponentInParent<Rigidbody>();
        _SubPos = transform.parent;
        Initialize();
    }

    private void Initialize()
    {
        float volume = _Rb.mass / Density;
        float archmagni = 1000f * Mathf.Abs(Physics.gravity.y) * volume;
        _Archimedes = new Vector3(0, archmagni, 0);
    }

    public void ApplyBuoyancy( float Power)
    {
        Vector3 wp = transform.TransformPoint(transform.position);
        float _water = WaterLevel();

        if (transform.position.y < _water)
        {
            float _F = _water - transform.position.y + 0.5f;
            if (_F > 1)
            {
                _F = 1f;
            }
            else if (_F < 0)
            {
                _F = 0f;
            }
            Vector3 velocity = _Rb.GetPointVelocity(wp);
            Vector3 DampForce = -velocity * DampeningFactor * _Rb.mass;
            Vector3 _Force = DampForce + Mathf.Sqrt(_F) * _Archimedes;
            _Rb.AddForce(_Force * Power * Speed);
        }
    }

    private float WaterLevel()
    {
        if (Water != null) return Water.position.y;
        else return 0;
    }

}
