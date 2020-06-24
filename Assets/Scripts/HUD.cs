using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Image Pointer;
    [SerializeField] private Transform Submarine;
    [SerializeField] private Text _DepthText;
    [SerializeField] private Slider _DepthSlider;
    [SerializeField] private Submarine _Sub;
    [SerializeField] private Slider ThrustSlider;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))TargetPointer();
    }
    private void FixedUpdate()
    {
        _DepthText.text = ($"Depth of {Mathf.Round(Submarine.transform.position.y)} Meters");
        _DepthSlider.value = _Sub._CurrentForce;
        ThrustSlider.value = (Input.GetAxis("Vertical"));
    }

    void TargetPointer()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.transform.gameObject.layer == 8)
            {
                _Sub._Weapons.Target = hit.transform;
                Debug.Log("New target of weapons is " + hit.transform.name);
                Pointer.transform.position = hit.point;
            }
        }
    }

}
