using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        transform.position = Player.transform.position + new Vector3(Random.onUnitSphere.y * 25, 0.5f, Random.onUnitSphere.x * 25);
    }

    // Update is called once per frame
    void Update()
    {
        target = Player.transform.position; 
        FollowTarget();
    }

    void FollowTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * 3);
    }
}