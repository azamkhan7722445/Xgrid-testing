using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ResetARSession : MonoBehaviour
{
    [SerializeField] private ARSession arSession;
    private void OnEnable()
    {
        arSession.subsystem.Start();
    }
    private void OnDisable()
    {
        arSession.subsystem.Stop();
    }
}
