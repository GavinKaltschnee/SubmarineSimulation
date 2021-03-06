﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Propeller : MonoBehaviour
{
    #region Variables
    public float Power { get => _Power; set => _Power = value; }
    [SerializeField] private float _Power = 100;
    [SerializeField] private Rigidbody _Rb;
    [SerializeField] private GameObject _Particles;
    [SerializeField] private Transform _Visual;
    [SerializeField] private _Type Type;
    [SerializeField] private bool Invert = false;
    private float _Invert = 1;
    private enum _Type { Vertical, Horizontal, Constant};
    private float _Thrust = 0;
    #endregion Variables

    private void Awake()
    {
        if (Invert) { _Invert = -1; }
        else _Invert = 1;
    }
    private void FixedUpdate()
    {
        if (_Thrust < _Power)
        {
            _Particles.SetActive(false);
        }
    }

    public void SetThrust(float Force)
    {
        _Particles.SetActive(true);
        RotateVisual(_Visual, 1000);
        _Thrust = _Power * Force;
        Mathf.Clamp(_Thrust, -250, 250);
        _Rb.AddForceAtPosition((transform.forward * _Invert)* _Thrust, transform.position, ForceMode.Force);
    }

    private void RotateVisual(Transform Screw,float Speed)
    {
        if (Type != _Type.Constant)
        {
            Screw.Rotate(Vector3.forward * Input.GetAxis(Type.ToString()) * Speed * Time.deltaTime);
        }
        else
        {
            Screw.Rotate(Vector3.forward * Speed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()//Debug\
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.forward * 5000f * _Invert);
    }
}
