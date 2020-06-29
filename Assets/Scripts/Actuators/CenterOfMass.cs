using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour
{
    [SerializeField] private Rigidbody _Rb;

    // Update is called once per frame
    void Update()
    {
        _Rb.centerOfMass = this.transform.localPosition;
    }
}
