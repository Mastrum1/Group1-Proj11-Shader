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

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Shooting>().shooted > shoot)
        {
            mesh.material.SetFloat("_FresnelPower", mesh.material.GetFloat("_FresnelPower") - 0.1f);
            shoot = player.GetComponent<Shooting>().shooted;
        }
    }
}
