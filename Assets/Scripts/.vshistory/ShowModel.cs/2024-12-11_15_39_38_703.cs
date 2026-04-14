using GaussianSplatting.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModel : MonoBehaviour
{
    [SerializeField] private List<GaussianSplatAsset> gaussianSplatAssets = new List<GaussianSplatAsset>();
    [SerializeField] private GaussianSplatRenderer gaussianSplatRenderer;
    [SerializeField] private float totalFramePerSec = 30f;
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
        /*delayTime = gaussianSplatAssets.Count * 1;
        delayTime=delayTime/totalFramePerSec;
        delayTime= delayTime/gaussianSplatAssets.Count;
        Debug.Log(delayTime);*/
        delayTime = 1f / totalFramePerSec;
        while (true)
        {
            yield return new WaitForSeconds(delayTime);
            //yield return new WaitForEndOfFrame();
            if (index >= gaussianSplatAssets.Count)
            {                
                index = 0;
            }
            gaussianSplatRenderer.asset=null;            
            gaussianSplatRenderer.asset = gaussianSplatAssets[index];
            index++;
        }
    }
}
