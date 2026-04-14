using GaussianSplatting.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModel : MonoBehaviour
{
    [SerializeField] private List<GaussianSplatAsset> gaussianSplatAssets = new List<GaussianSplatAsset>();
    [SerializeField] private GaussianSplatRenderer gaussianSplatRenderer;
    [SerializeField] private float totalFramePerSec = 30f;
    private int index = 0;
    float delayTime = 0;

    private void Reset()
    {
        name = nameof(ShowModel);
        transform.position = Vector3.zero;
    }
    private void Start()
    {
        ShowModelsFrameWise();
    }
    public void ShowModelsFrameWise()
    {
        if (gaussianSplatAssets.Count != 0)
        {
            StartCoroutine(CR_ShowModelsFrameWise());
        }
    }

    private IEnumerator CR_ShowModelsFrameWise()
    {
        delayTime = (gaussianSplatAssets.Count * 1);
        delayTime = delayTime / totalFramePerSec;
        delayTime = delayTime / gaussianSplatAssets.Count;
        delayTime = 1f / totalFramePerSec;
        Debug.Log(delayTime);
        while (true)
        {
            yield return new WaitForSeconds(delayTime);
            if (index >= gaussianSplatAssets.Count)
            {
                StopAllCoroutines();
                yield break;
                //index = 0;
            }
            gaussianSplatRenderer.asset = gaussianSplatAssets[index];
            index++;
        }
    }
}
