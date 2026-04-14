using GaussianSplatting.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModel : MonoBehaviour
{
    [SerializeField] private List<GaussianSplatAsset> gaussianSplatAssets = new List<GaussianSplatAsset>();
    [SerializeField] private GaussianSplatRenderer gaussianSplatRenderer;
    private int index = 0;

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
        var watchTime = Time.time;
        Debug.Log(watchTime);
        while (true)
        {
            float delayTime = (gaussianSplatAssets.Count * 1) / 30;
            delayTime = delayTime / gaussianSplatAssets.Count;
            watchTime += Time.deltaTime;
            yield return new WaitForSeconds(delayTime);
            if (index >= gaussianSplatAssets.Count)
            {
                Debug.Log(watchTime);
                StopAllCoroutines();
                yield break;
                //index = 0;
            }
            gaussianSplatRenderer.asset = gaussianSplatAssets[index];
            index++;
        }
    }
}
