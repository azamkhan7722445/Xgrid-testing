using GaussianSplatting.Runtime;
using System;
using System.Collections.Generic;
using System.Reflection;
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
        delayTime = 1f / totalFramePerSec;
        while (true)
        {
            yield return new WaitForSeconds(delayTime);
            //yield return new WaitForEndOfFrame();
            if (index >= gaussianSplatAssets.Count)
            {
                index = 0;
            }
            gaussianSplatRenderer.asset = null;
            gaussianSplatRenderer.asset = gaussianSplatAssets[index];
            index++;
        }
    }
}
