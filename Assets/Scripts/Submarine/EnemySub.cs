﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySub : MonoBehaviour
{
    [SerializeField] private Propeller _MainPropeller;
    [SerializeField] private Sub_Variant SubClass;

    private void FixedUpdate()
    {
        if (_MainPropeller != null) { _MainPropeller.SetThrust(0.75f); }
    }
}
