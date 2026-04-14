using GaussianSplatting.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModel : MonoBehaviour
{
    [SerializeField] private List<GaussianSplatAsset> gaussianSplatAssets = new List<GaussianSplatAsset>();
    [SerializeField] private GaussianSplatRenderer gaussianSplatRenderer;
    private int index = 0;
    private bool isOverTime = false;
    private float watchTime = 0;
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
        while (true)
        {
            float delayTime = (gaussianSplatAssets.Count * 1) / 30;
            delayTime /= gaussianSplatAssets.Count;

            Debug.Log(delayTime+"=="+1.7f / 51);
            yield return new WaitForSeconds(delayTime);
            //yield return new WaitForSeconds(1.7f/51);

            if (index >= gaussianSplatAssets.Count)
            {
                isOverTime = true;
                StopAllCoroutines();
                yield break;
                //index = 0;
            }
            gaussianSplatRenderer.asset = gaussianSplatAssets[index];
            index++;
        }
    }
    private void Update()
    {
        if (!isOverTime)
        {            
            watchTime += Time.deltaTime;
           // Debug.Log(watchTime);
        }
    }
}
