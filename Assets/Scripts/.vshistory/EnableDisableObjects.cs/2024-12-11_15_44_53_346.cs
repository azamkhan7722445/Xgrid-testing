using GaussianSplatting.Runtime;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableObjects : MonoBehaviour
{
    [SerializeField] private List<GameObject> frameObjects = new List<GameObject>();
    void Start()
    {
        if (frameObjects.Count != 0)
        {
            StartCoroutine(CR_ShowHideModel());
        }
    }

    private string CR_ShowHideModel()
    {
        
    }
}
