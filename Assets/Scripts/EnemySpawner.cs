using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject enemies;
    [SerializeField] public GameObject[] spawnpoint;
    [SerializeField] public GameObject player;
    [SerializeField] public int randomspawn;
    // Start is called before the first frame update
    void Start()
    {
        spawnpoint = GameObject.FindGameObjectsWithTag("Spawn");
        InvokeRepeating("Spawn", 1, 5);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Spawn()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position;
        randomspawn = Random.Range(0,spawnpoint.Length);
        Instantiate(enemies, spawnpoint[randomspawn].transform);
    }
}
