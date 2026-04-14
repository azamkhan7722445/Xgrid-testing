using System.Collections;
using UnityEngine;
using UnityEngine.Windows;
public class PLYSequencePlayer : MonoBehaviour
{
    public string folderPath = "Assets/PLYSequence"; // Path to your PLY files
    public string filePrefix = "frame"; // File prefix
    public string fileExtension = ".ply"; // File extension
    public int frameCount = 100; // Total number of frames
    public float frameRate = 30f; // Playback frame rate
    private MeshFilter meshFilter;
    private float frameTime;
    private int currentFrame = 0;
    private bool isPlaying = true;
    private Mesh currentMesh;
    private Mesh nextMesh;
    private float interpolationProgress = 0f;
    byte[] data;
    void Start()
    {
        // Set the frame time
        frameTime = 1f / frameRate;
        // Get the MeshFilter component
        meshFilter = GetComponent<MeshFilter>();
        if (!meshFilter)
        {
            Debug.LogError("MeshFilter component missing!");
            enabled = false;
        }
        // Load the first frame
        currentMesh = LoadPLY(GetFileName(currentFrame));
        nextMesh = LoadPLY(GetFileName((currentFrame + 1) % frameCount));
        StartCoroutine(PlaySequence());
    }
    IEnumerator PlaySequence()
    {
        while (isPlaying)
        {
            yield return new WaitForEndOfFrame();
            // Interpolate between currentMesh and nextMesh
            if (currentMesh != null && nextMesh != null)
            {
                interpolationProgress = 0f;
                while (interpolationProgress < 1f)
                {
                    interpolationProgress += Time.deltaTime / frameTime;
                    meshFilter.mesh = InterpolateMeshes(currentMesh, nextMesh, interpolationProgress);
                    yield return null;
                }
            }
            // Advance to the next framecurrentFrame = (currentFrame + 1) % frameCount;
            currentMesh = nextMesh;
            nextMesh = LoadPLY(GetFileName((currentFrame + 1) % frameCount));
        }
    }
    private Mesh InterpolateMeshes(Mesh meshA, Mesh meshB, float t)
    {
        // Create a new mesh to store interpolated data
        Mesh interpolatedMesh = new Mesh();
        // Interpolate vertex positions
        Vector3[] verticesA = meshA.vertices;
        Vector3[] verticesB = meshB.vertices;
        Vector3[] interpolatedVertices = new
        Vector3[verticesA.Length];
        for (int i = 0; i < verticesA.Length; i++)
        {
            interpolatedVertices[i] = Vector3.Lerp(verticesA[i], verticesB[i], t);
        }
        // Interpolate normals(optional, for smooth lighting)
        Vector3[] normalsA = meshA.normals;
        Vector3[] normalsB = meshB.normals;
        Vector3[] interpolatedNormals = new Vector3[normalsA.Length];
        for (int i = 0; i < normalsA.Length; i++)
        {
            interpolatedNormals[i] = Vector3.Lerp(normalsA[i], normalsB[i], t).normalized;
        }
        // Set interpolated data to the mesh
        interpolatedMesh.vertices = interpolatedVertices;
        interpolatedMesh.normals = interpolatedNormals;
        interpolatedMesh.triangles = meshA.triangles; // Assume same topology
        return interpolatedMesh;
    }
    private Mesh LoadPLY(string filePath)
    {
data=File.ReadAllBytes(filePath);
        // Implement your PLY loading logic here
        // Return a Unity Mesh object
        return null; // Replace with actual implementation
    }

    private string GetFileName(int frameIndex)
    {
        var path = $"{folderPath}frame{fileExtension}";
        //var path = $"{folderPath}frame_210{frameIndex}{fileExtension}";
        Debug.Log(path);
        return path;
    }
}