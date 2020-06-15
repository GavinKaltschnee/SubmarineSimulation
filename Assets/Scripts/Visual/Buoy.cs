using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoy : MonoBehaviour
{
    #region Variables
    private float _Ballast;
    [SerializeField]private Rigidbody _Rb;
    public BoxCollider Water;
    private Transform _Pos;
    private Vector3 _Archimedes;
    private float _Mass;
    #endregion Variables

    private void Start()
    {
        if (_Rb ==null)_Rb = GetComponent<Rigidbody>();
        _Mass = _Rb.mass;
        _Pos = this.transform;
        float volume = _Rb.mass / 500f;
        float archmagni = 1000f * Mathf.Abs(Physics.gravity.y) * volume;
        _Archimedes = new Vector3(0, archmagni, 0);
    }
    public void CalculateBallast(float Power)
    {
        var wp = transform.TransformPoint(transform.position);
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
            var velocity = _Rb.GetPointVelocity(wp);
            var DampForce = -velocity * 0.1f * _Rb.mass;
            var _force = DampForce + Mathf.Sqrt(_F) * _Archimedes;
            //_Rb.AddForceAtPosition(_force * Power, wp);
            _Rb.AddForce(_force * Power);
        }
    }
    private float WaterLevel()
    {
        if (Water != null) return Water.bounds.extents.y;
        else return 0;
    }
    private void FixedUpdate()
    {
        if (_Pos.position.y < WaterLevel())
        {
            CalculateBallast(0.6f);
        }
        if (_Pos.position.y > WaterLevel())
        {
            _Rb.velocity = new Vector3(0,0,0);
        }

    }
}
