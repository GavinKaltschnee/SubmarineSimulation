using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underwater : MonoBehaviour
{
    public float waterHeight;
    private bool _Underwater;
    [SerializeField] private float FogDensity = 0.1f;
    private Color underwaterColor;

    void Start()
    {
        underwaterColor = new Color(0.23f, 0.60f, 0.76f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.y < waterHeight) != _Underwater)
        {
            _Underwater = transform.position.y < waterHeight;
            if (_Underwater)
            {
                Submerged();
            }
            if (!_Underwater)
            {
                AboveWater();
            }
        }
    }

    void AboveWater()
    {
        RenderSettings.fogDensity = 0f;
    }

    void Submerged()
    {
        RenderSettings.fogColor = underwaterColor;
        RenderSettings.fogDensity = FogDensity;
    }
}

