using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMeshGenerator : MonoBehaviour
{
    public Material _MeshMaterial;

    void Start()
    {
        MakeTriangle();
        //MakeQuad();
        //MakeDoubleQuad();
    }

    void MakeTriangle()
    {
        Vector3[] _verticles = new Vector3[] 
        {
            new Vector3(0, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 0, 0)
        };

        int[] _indices = new int[]
        {
            0, 1, 2
        };

        Color[] colors = new Color[]
        {
            Color.red, Color.green, Color.blue
        };

        Vector2[] uvs = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(0, 1),
            new Vector2(1, 0),
        };

        BuildMesh("DemoTriangle", _verticles, _indices, uvs, null);
    }

    void MakeQuad()
    {
        Vector3[] _verticles = new Vector3[] 
        {
            new Vector3(0, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 0, 0),
            new Vector3(1, 1, 0),

        };

        int[] _indices = new int[]
        {
            0,1,2,1,3,2
        };

        BuildMesh("DemoQuad", _verticles, _indices);
    }

    void MakeDoubleQuad()
    {
        Vector3[] _verticles = new Vector3[] 
        {
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 1, 0),
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
        };

        int[] _indices = new int[]
        {
            0,1,2,3,5,4
        };

    }

    protected void BuildMesh(string gameObjectName, Vector3[] vertices, int[] indices, Vector2[] uvs = null, Color[] colors = null)
    {
        // Search in the scene if there is a GameObject called "gameObjectName". If yes, we destroy it.
        GameObject oldOne = GameObject.Find(gameObjectName);
        if (oldOne != null)
            DestroyImmediate(oldOne);

        // Create a GameObject
        GameObject primitive = new GameObject(gameObjectName);
        
        // Add the components...
        MeshRenderer meshRenderer = primitive.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = primitive.AddComponent<MeshFilter>();
      
        // ... and set the mesh buffers. 
        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.triangles = indices;
        meshFilter.mesh.uv = uvs;
        meshFilter.mesh.colors = colors;

        // Apply the material.
        meshRenderer.material = _MeshMaterial != null ? _MeshMaterial : new Material(Shader.Find("Universal Render Pipeline/Unlit"));
    }
}
