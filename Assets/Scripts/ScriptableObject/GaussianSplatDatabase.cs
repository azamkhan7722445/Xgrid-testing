using UnityEngine;
using System.Collections.Generic;
using GaussianSplatting.Runtime;

[CreateAssetMenu(fileName = "GaussianSplatDatabase", menuName = "Gaussian Splats/Database")]
public class GaussianSplatDatabase : ScriptableObject
{
    [SerializeField, HideInInspector] private string assetFolderPath = "Assets/GaussianSplats";
    [SerializeField] private List<GaussianSplatAsset> gaussianSplatAssets = new List<GaussianSplatAsset>();

    public string AssetFolderPath => assetFolderPath;
    public List<GaussianSplatAsset> Assets => gaussianSplatAssets;

#if UNITY_EDITOR
    public void SetFolderPath(string newPath)
    {
        assetFolderPath = newPath;
        UnityEditor.EditorUtility.SetDirty(this);
    }

    public void LoadAllFromFolder()
    {
        gaussianSplatAssets.Clear();

        string[] guids = UnityEditor.AssetDatabase.FindAssets("t:GaussianSplatAsset", new[] { assetFolderPath });

        foreach (string guid in guids)
        {
            string path = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
            var asset = UnityEditor.AssetDatabase.LoadAssetAtPath<GaussianSplatAsset>(path);
            if (asset != null)
                gaussianSplatAssets.Add(asset);
        }

        UnityEditor.EditorUtility.SetDirty(this);
        UnityEditor.AssetDatabase.SaveAssets();

        Debug.Log($"Loaded {gaussianSplatAssets.Count} GaussianSplatAssets from {assetFolderPath}");
    }
#endif
}
