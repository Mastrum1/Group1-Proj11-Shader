using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPosition : MonoBehaviour
{
    public GameObject player;
    private float shoot = 0;
    private MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shoot = player.GetComponent<Shooting>().shooted;
        mesh = GetComponent<MeshRenderer>();
    }

    void Cooling()
    {
        mesh.material.SetFloat("_Fill", mesh.material.GetFloat("_Fill") - 0.1f);
    }

    // Update is called once per frame
    async void Update()
    {
        if (player.GetComponent<Shooting>().shooted > shoot && mesh.material.GetFloat("_Fill") != 1f)
        {
            mesh.material.SetFloat("_Fill", mesh.material.GetFloat("_Fill") + 0.1f);
            shoot = player.GetComponent<Shooting>().shooted;
            Invoke("Cooling", 5);
        }
    }
}
