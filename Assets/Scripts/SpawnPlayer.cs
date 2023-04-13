using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    private SkinnedMeshRenderer m_Renderer;
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Renderer.material.GetInteger("_Spawn") == 1)
        {
            m_Renderer.material.SetInteger("_Spawn", 0);
        }
    }
}
