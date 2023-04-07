using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject[] enemies;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemies");
    }

    private void Start()
    {
        InvokeRepeating("Shoot", 1, 1);
    }

    void Shoot()
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        for(int i = 0; i < enemies.Length; i++)
        {
            float dist = Vector3.Distance(enemies[i].transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = enemies[i].transform;
                minDist = dist;
            }
        }
        Debug.Log(tMin.position.x);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(tMin.position, ForceMode.Impulse);
    }
}
