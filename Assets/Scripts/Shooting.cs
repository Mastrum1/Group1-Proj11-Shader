using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject[] enemies;
    Transform tMin = null;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemies");
        tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        for (int i = 0; i < enemies.Length; i++)
        {
            float dist = Vector3.Distance(enemies[i].transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = enemies[i].transform;
                minDist = dist;
            }
        }
    }

    private void Start()
    {
        InvokeRepeating("Shoot", 1, 1);
    }

    void Shoot()
    {
        Vector3 distance = tMin.position - transform.position;
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(firePoint.position.x, 1, firePoint.position.z), firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(distance, ForceMode.Impulse);
    }
}
