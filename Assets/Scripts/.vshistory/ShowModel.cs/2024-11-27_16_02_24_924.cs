using GaussianSplatting.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModel : MonoBehaviour
{
    [SerializeField] private List<GaussianSplatAsset> gaussianSplatAssets = new List<GaussianSplatAsset>();
    [SerializeField] private GaussianSplatRenderer gaussianSplatRenderer;
    private int index = 0;
    private float startTime;
    private float elapsedTime;
    private float seconds;

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
        startTime = Time.time;
        while (true)
        {
            int minutes = (int)elapsedTime / 60;
            seconds = (int)elapsedTime % 60;

            yield return new WaitForSeconds(seconds);
            //yield return new WaitForEndOfFrame();
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
    public void Update()
    {
        elapsedTime = Time.time - startTime;
    }
}
