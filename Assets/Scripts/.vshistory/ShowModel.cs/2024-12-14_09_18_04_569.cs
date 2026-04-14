using GaussianSplatting.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModel : MonoBehaviour
{
    [SerializeField] private List<GaussianSplatAsset> gaussianSplatAssets = new List<GaussianSplatAsset>();
    [SerializeField] private GaussianSplatRenderer gaussianSplatRenderer;
    [SerializeField] private float totalFramePerSec = 30f;
    [SerializeField] private bool loopPlay = true;
    [SerializeField]private int index = 0;
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
        delayTime = 1f / totalFramePerSec;
        while (true)
        {
            yield return new WaitForSeconds(delayTime);            
            if (index >= gaussianSplatAssets.Count)
            {
                if (loopPlay)
                {
                    index = 0;
                }
                else
                {
                    index = 0;
                    StopAllCoroutines();
                }
            }
            gaussianSplatRenderer.asset=null;            
            gaussianSplatRenderer.asset = gaussianSplatAssets[index];
            index++;
        }
    }
}
