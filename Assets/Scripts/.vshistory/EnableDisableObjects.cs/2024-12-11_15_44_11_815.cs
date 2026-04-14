using GaussianSplatting.Runtime;
using UnityEngine;

public class EnableDisableObjects : MonoBehaviour
{
    void Start()
    {
        if (gaussianSplatAssets.Count != 0)
        {
            StartCoroutine(CR_ShowHideModel());
        }
    }
}
