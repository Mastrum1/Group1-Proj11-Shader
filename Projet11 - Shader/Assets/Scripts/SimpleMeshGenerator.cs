using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SimpleMeshGenerator : MonoBehaviour
{
    public Material _MeshMaterial;

    void Start()
    {
        MakeTriangle();
        MakeQuad();
        MakeDoubleQuad();
    }

    void MakeTriangle()
    {
        Vector3[] _verticles = new Vector3[3];
        _verticles[0] = new Vector3 (0, 0, 0);
        _verticles[1] = new Vector3 (1, 0, 0);
        _verticles[2] = new Vector3 (0, 1, 0);

        int[] _indices = new int[3];
        _indices[0] = 0;
        _indices[1] = 1;
        _indices[2] = 2;

        BuildMesh("DemoTriangle", _verticles, _indices);
    }

    void MakeQuad()
    {
        Vector3[] _verticles = new Vector3[] 
        {
            new Vector3(0, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 1, 0),
            new Vector3(1, 0, 0),
        };

        int[] _indices = new int[]
        {
            0,1,2,3,4,5
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

    protected void BuildMesh(string gameObjectName, Vector3[] vertices, int[] indices, Vector2[] uvs = null)
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

        // Apply the material.
        meshRenderer.material = _MeshMaterial != null ? _MeshMaterial : new Material(Shader.Find("Universal Render Pipeline/Unlit"));
    }
}
