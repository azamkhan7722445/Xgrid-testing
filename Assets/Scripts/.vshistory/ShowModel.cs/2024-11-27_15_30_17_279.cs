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
        Debug.Log("Start Time : " + Time.deltaTime);
        while (true)
        {
            yield return new WaitForSeconds(1.7f / 30);
            //yield return new WaitForEndOfFrame();
            if (index >= gaussianSplatAssets.Count)
            {
                Debug.Log("End Time : " + Time.deltaTime);
                StopAllCoroutines();
                yield break;
                //index = 0;
            }
            gaussianSplatRenderer.asset = gaussianSplatAssets[index];
            index++;
        }
    }
}
