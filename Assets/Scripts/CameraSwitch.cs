using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private Camera _MainCamera;
    [SerializeField] private Vector3 FirstPerson;
    [SerializeField] private Vector3 ThirdPerson;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))//Neutral Buoyancy (toggle on to stay neutral or off to surface)
        {
            if (_MainCamera.transform.localPosition != FirstPerson)
            {
                _MainCamera.transform.localPosition= FirstPerson;
                _MainCamera.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                _MainCamera.transform.localPosition = ThirdPerson;
                _MainCamera.transform.localRotation = Quaternion.Euler(20, 0, 0);
            }
        }
    }
}
