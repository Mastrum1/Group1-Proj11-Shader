using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour
{
    private SkinnedMeshRenderer mesh;
    private float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mesh.material.GetFloat("_Spawn") == 1)
        {
            float fill = mesh.material.GetFloat("_CutOff_Height");
            if (fill > -2)
            {
                fill -= fill * Time.deltaTime * speed + 0.01f;
                if (fill < -0.48f)
                {
                    fill = -1f;
                }
                mesh.material.SetFloat("_CutOff_Height", fill);
            }
            else
            {
                mesh.material.SetFloat("_Spawn", 0);
                mesh.material.SetFloat("_CutOff_Height", -1f);
            }
        }
    }
}
