using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealEffect : MonoBehaviour
{
    private SkinnedMeshRenderer mesh;
    private float force = 3f;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mesh.material.GetFloat("_Healing") == 1)
        {
            float fill = mesh.material.GetFloat("_Fill");
            if (fill < 1)
            {
                fill += fill * Time.deltaTime * force;
                mesh.material.SetFloat("_Fill", fill);
            }
            else
            {
                mesh.material.SetFloat("_Healing", 0);
                mesh.material.SetFloat("_Fill", 0.10f   );
            }
        }
    }
}
