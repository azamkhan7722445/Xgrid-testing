using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GaussianSplatDatabase))]
public class GaussianSplatDatabaseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var database = (GaussianSplatDatabase)target;

        // Display current folder path
        EditorGUILayout.LabelField("Asset Folder Path:", EditorStyles.boldLabel);
        EditorGUILayout.LabelField(database.AssetFolderPath, EditorStyles.wordWrappedLabel);

        // Folder browser button
        if (GUILayout.Button("Browse Folder"))
        {
            string selected = EditorUtility.OpenFolderPanel("Select Gaussian Splats Folder", "Assets", "");
            Debug.Log(selected);
            if (!string.IsNullOrEmpty(selected))
            {
                // Convert absolute path to relative project path (Unity requires relative)
                string projectPath = Application.dataPath;
                if (selected.StartsWith(projectPath))
                {
                    selected = "Assets" + selected.Substring(projectPath.Length);
                }

                database.SetFolderPath(selected);
            }
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Load All GaussianSplatAssets from Folder"))
        {
            database.LoadAllFromFolder();
        }

        EditorGUILayout.Space();

        DrawDefaultInspector();
    }
}
