using GaussianSplatting.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EnableDisableObjects : MonoBehaviour
{
    [SerializeField] private List<GameObject> frameObjects = new List<GameObject>();
    [SerializeField] private float totalFramePerSec = 30f;
    [SerializeField] private int index = 0;
    float delayTime = 0;
    void Start()
    {
        if (frameObjects.Count != 0)
        {
            StartCoroutine(CR_ShowHideModel());
        }
    }

    private IEnumerator CR_ShowHideModel()
    {
        delayTime = 1f / totalFramePerSec;
        while (true)
        {
            yield return new WaitForSeconds(delayTime);
            //yield return new WaitForEndOfFrame();
            if (index >= frameObjects.Count)
            {
                index = 0;
            }
            DisableAllObject();
            frameObjects[index].SetActive(true);
            index++;
        }
    }

    private void DisableAllObject()
    {
    }
}
