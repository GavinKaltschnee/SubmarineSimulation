using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HeatSeeking : MonoBehaviour
{
    public bool Active;
    private Transform _Target;
    private WeaponController _Main;
    [SerializeField] float SeekingRange = 10f;

    private void OnEnable()
    {
        _Main = GetComponentInParent<WeaponController>();
        _Main.Fired.AddListener(Activate);
        _Main.Reloaded.AddListener(DeActivate);
    }
    private void OnDisable()
    {
        _Main.Fired.RemoveListener(Activate);
        _Main.Reloaded.RemoveListener(DeActivate);
    }
    IEnumerator ObtainTarget()
    {
        while(Active)
        {
            Collider[] Targets = Physics.OverlapSphere(transform.position, SeekingRange);
            foreach(Collider Obj in Targets)
            {
                if (Obj.gameObject.CompareTag("Player"))
                {
                    _Target = Obj.transform;
                    StartCoroutine("SeekTarget");
                    yield break;
                }
            }
            yield return new WaitForFixedUpdate();
            yield return null;
        }
    }

    IEnumerator SeekTarget()
    {
        Vector3 _Direction = _Target.gameObject.GetComponent<Rigidbody>().velocity;
        while(Active)
        {
            if (Vector3.Distance(transform.position, _Target.position)< 25f) { yield break; }
            if (_Direction == null) { transform.LookAt(_Target); yield break; }
            Vector3 TargetPosition = _Target.position + _Direction * 2;
            transform.LookAt(TargetPosition);
            yield return null;
        }
    }

    void Activate()
    {
        Active = true;
        if (_Main.Target == null) StartCoroutine("ObtainTarget");
        else
        {
            _Target = _Main.Target;
            StartCoroutine("SeekTarget");
        }
    }

    void DeActivate()
    {
        Debug.Log("Projectile stopped tracking");
        _Target = null;
        Active = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Active = false;
            Debug.Log("torpedo hit enemy");
        }
    }
}
