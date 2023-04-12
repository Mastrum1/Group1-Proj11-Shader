using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int enemyHP = 3;
    public GameObject healthPack;
    public GameObject body;
    // Start is called before the first frame update
    void Start()
    {
        body = GameObject.Find("Soldier_body");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHP <= 0)
        {
            if (Random.Range(1,10) == 1)
            {
                Instantiate(healthPack, transform.position + Vector3.up, transform.rotation);
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet") 
        {
            enemyHP--;
            body.GetComponent<SkinnedMeshRenderer>().material.SetFloat("_Damage", 1);
        }
    }
}
