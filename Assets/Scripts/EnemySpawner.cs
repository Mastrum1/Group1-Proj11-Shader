using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject enemies;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1, 5);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Spawn()
    {
        Instantiate(enemies);
    }
}
