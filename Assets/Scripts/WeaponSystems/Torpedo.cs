using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    [SerializeField] private BallastTank _Ballast;
    [SerializeField] private Propeller _Propeller;
    [SerializeField] private ParticleSystem Bubbles;
    [SerializeField] private TrailRenderer Trail;
    private Rigidbody _Rb;
    public bool _Active = false;

    void Start()
    {
        _Rb = GetComponent<Rigidbody>();
        DeActivate();
    }

    void SetBallast()
    {
        float F = _Rb.velocity.y;
        if (_Ballast != null) _Ballast.ApplyBuoyancy(-F);
    }
    public void Activate()
    {
        _Active = true;
        _Rb.isKinematic = false;
        Trail.enabled = true;
        Bubbles.gameObject.SetActive(true);
        transform.parent = null;
        StartCoroutine("Fire");
    }
    public void DeActivate()
    {
        _Active = false;
        _Rb.isKinematic = true;
        Trail.enabled = false;
        Bubbles.gameObject.SetActive(false);
    }
    private IEnumerator Fire()
    {
        while (_Active)
        {
            SetBallast();
            _Propeller.SetThrust(0.75f);
            yield return new WaitForFixedUpdate();
            yield return null;
        }
    }
}
