using UnityEngine;
using LCCCore;


public class LCCRenderer : MonoBehaviour
{
    public LCCManager m_manager;
    public string m_FilePath;
    private LCCCore.Renderer m_renderer;

    void Start()
    {
        m_renderer = m_manager.GetRender(this.transform);
        m_renderer.Load(m_FilePath, PlatformType.Quest, onLoadCallback);
    }

    private void onLoadCallback()
    {
        Debug.Log("data loaded !!!");
    }
}