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
    const float Dist = 15f;

    void Update()
    {
        //Vector3 pos = Camera.main.WorldToScreenPoint(_Sub.transform.position + (_Sub.transform.forward.normalized * Dist));

        //Pointer.transform.position = pos;
    }
    private void FixedUpdate()
    {
        _DepthText.text = ($"Depth of {Mathf.Round(Submarine.transform.position.y)} Meters");
        _DepthSlider.value = _Sub._CurrentForce;
        ThrustSlider.value = (Input.GetAxis("Vertical"));
    }
}
