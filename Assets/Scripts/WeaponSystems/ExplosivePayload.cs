using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExplosivePayload : MonoBehaviour
{
    private Buoy _Buoyancy;
    [SerializeField] private ParticleSystem Explosion;
    [SerializeField] private string EnemyTag;
    [SerializeField] private UnityEvent HitTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(EnemyTag))
        {
            Explode(other.gameObject);
            HitTarget.Invoke();
        }
    }

    private void Explode(GameObject Other)
    {
        Explosion.Play();
        Rigidbody Rb = Other.GetComponent<Rigidbody>();
        Vector3 random = new Vector3(Random.Range(0, 15), Random.Range(0, 15), Random.Range(0, 15));
        float Force = Mathf.Pow(Rb.mass, 3);
        Rb.AddExplosionForce(Force, transform.position + random, 100, 50);
    }
}
