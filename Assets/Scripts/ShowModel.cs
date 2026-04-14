using GaussianSplatting.Runtime;
using System.Collections;
using UnityEngine;

public class ShowModel : MonoBehaviour
{
    [SerializeField] GaussianSplatDatabase gaussianSplatDB;
    [SerializeField] private GaussianSplatRenderer gaussianSplatRenderer;
    [SerializeField] private float totalFramePerSec = 30f;
    [SerializeField] private bool loopPlay = true;
    [SerializeField] private bool playOnStart = true;
    [SerializeField] private int index = 0;
    float delayTime = 0;
    public GaussianSplatRenderer GaussianSplatRenderer { get => gaussianSplatRenderer; set => gaussianSplatRenderer = value; }
    public GaussianSplatDatabase GaussianSplatDB { get => gaussianSplatDB; set => gaussianSplatDB = value; }
    Coroutine ShowModelCoroutine;
    private void Reset()
    {
        name = nameof(ShowModel);
        transform.position = Vector3.zero;
    }
    private void Start()
    {
        if (playOnStart)
        {
            ShowModelsFrameWise();
        }
    }
    [ContextMenu(nameof(ShowModelsFrameWise))]
    public void ShowModelsFrameWise()
    {
        if (gaussianSplatDB.Assets.Count != 0)
        {
            ShowModelCoroutine = StartCoroutine(CR_ShowModels());            
        }
    }

    private IEnumerator CR_ShowModels()
    {
        index = 0;
        delayTime = 1f / totalFramePerSec;
        do
        {
            gaussianSplatRenderer.asset = null;
            gaussianSplatRenderer.asset = gaussianSplatDB.Assets[index];
            index++;
            yield return new WaitForSeconds(delayTime);
        }
        while (index < gaussianSplatDB.Assets.Count);
        gaussianSplatRenderer.asset = gaussianSplatDB.Assets[0];
        StopCoroutine(ShowModelCoroutine);
        if (loopPlay)
        {
            StartCoroutine(CR_ShowModels());
        }
    }
}
