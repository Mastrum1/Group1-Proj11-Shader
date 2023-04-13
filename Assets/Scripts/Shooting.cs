using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject enemy;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject flarePrefab;
    bool flareFired = false;

    public float bulletForce = 2f;
    public int shooted = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            ShootFlare();
        }
    }

    private void Start()
    {
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(firePoint.position.x, 1, firePoint.position.z), firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (enemy.GetComponent<RangeDetection>().enemyDetected != null)
        {
            Vector3 vector3 = enemy.GetComponent<RangeDetection>().enemyDetected.transform.position;
            Vector3 test = vector3 - transform.position;
            rb.AddForce(test * bulletForce, ForceMode.Impulse);
        }
        else
        {
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        }
        shooted++;
    }

    void ShootFlare()
    {
        if (!flareFired)
        {
            GameObject flare = Instantiate(flarePrefab, GameObject.FindGameObjectWithTag("Player").transform.position, firePoint.rotation);
            flareFired = true;
            Invoke("reloadFlare", 20);
        }
    }

    void reloadFlare()
    {
        flareFired = false;
    }
}
