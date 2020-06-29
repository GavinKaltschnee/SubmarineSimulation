using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private Buoy _Buoyancy;
    [SerializeField]private GameObject Explosion;

    private void Start()
    {
        _Buoyancy = GetComponent<Buoy>();
        Explosion.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            ActivateMine();
            Explode(other.gameObject);
        }
    }
    private void ActivateMine()
    {
        Explosion.SetActive(true);
        if (_Buoyancy !=null)_Buoyancy.enabled = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
    private void Explode(GameObject Other)
    {
        //Other.GetComponent<Submarine>().enabled = false;
        //Rigidbody Rb = Other.GetComponent<Rigidbody>();
        //Vector3 random = new Vector3(Random.Range(0, 15), Random.Range(0, 15), Random.Range(0, 15));
        //float Force = Mathf.Pow(Rb.mass, 3);
        //Rb.AddExplosionForce(Force, transform.position + random, 100, 50);
    }
}
