﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App_Initialize : MonoBehaviour
{
    private void Awake()
    {
        Shader.SetGlobalFloat("_Curvature", 2.0f);
        Shader.SetGlobalFloat("_Trimming", 0.1f);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}