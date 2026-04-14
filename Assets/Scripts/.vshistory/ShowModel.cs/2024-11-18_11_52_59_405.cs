using GaussianSplatting.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShowModel : MonoBehaviour
{
    [SerializeField] private InputAction inputAction;
    [SerializeField] private List<GaussianSplatAsset> gaussianSplatAssets = new List<GaussianSplatAsset>();
    [SerializeField] private GaussianSplatRenderer gaussianSplatRenderer;
    private int index = 0;
    private void OnEnable()
    {
        inputAction.Enable();
        inputAction.performed += Test;
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
            yield return new WaitForEndOfFrame();
            if (index >= gaussianSplatAssets.Count)
                index = 0;
            gaussianSplatRenderer.asset= gaussianSplatAssets[index];
            index++;
        }
    }
}
