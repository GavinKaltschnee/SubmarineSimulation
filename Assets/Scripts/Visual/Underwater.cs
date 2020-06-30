using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underwater : MonoBehaviour
{
    public Material _mat;
    public float waterHeight;
    private bool _Underwater;
    [SerializeField] private float FogDensity = 0.1f;
    [SerializeField] private Color underwaterColor = new Color(0.23f, 0.60f, 0.76f, 0.5f);
    private AudioSource _Ambience;

    private void Awake()
    {
        _Ambience = GetComponent<AudioSource>();
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
        _Ambience.volume = 0;
        _mat.SetFloat("_PixelOffset", 0);
        RenderSettings.fogDensity = 0f;
    }

    void Submerged()
    {
        _Ambience.volume = 1;
        _mat.SetFloat("_PixelOffset", 0.0025f);
        RenderSettings.fogColor = underwaterColor;
        RenderSettings.fogDensity = FogDensity;
    }
    private void OnDisable()
    {
        _mat.SetFloat("_PixelOffset", 0);
    }
}

