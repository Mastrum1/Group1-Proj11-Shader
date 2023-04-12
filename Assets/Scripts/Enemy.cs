using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int enemyHP = 3;
    public GameObject healthPack;
    public GameObject body;
    // Start is called before the first frame update
    [SerializeField] private Renderer[] shaders = new Renderer[0];
    private float disolve = 0;

    void Start()
    {
        body = GameObject.Find("Soldier_body");
    }

    // Update is called once per frame
    void Update()
    {

        if (enemyHP != 0)
        {

            if (disolve < 0.99f)
            {
                disolve = Mathf.Lerp(disolve, 1f, 2f * Time.deltaTime);

            }
            else
            {
                disolve = 1;
            }
            foreach (Renderer r in shaders)
            {
                foreach (Material m in r.materials)
                {

                    m.SetFloat("_Boolean", 1);
                    m.SetFloat("_disolvePerso", Mathf.Lerp(disolve, 0, 2f * Time.deltaTime));
                }

            }

        }

        if (enemyHP <= 0)
        {
            disolve = Mathf.Lerp(disolve, 0f, 2f * Time.deltaTime);
            if (disolve > 0.01f)
            {
                foreach (Renderer r in shaders) {
                    foreach (Material m in r.materials)
                    {
                        m.SetFloat("_Boolean", 0);
                        m.SetFloat("_disolvePerso", Mathf.Lerp(disolve, 0, 2f * Time.deltaTime));
                    }
                }
            }
            if (disolve <= 0.01f)
            {
                if (Random.Range(1, 2) == 1)
                {
                    Instantiate(healthPack, transform.position + Vector3.up, transform.rotation);
                }
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            enemyHP= Math.Max(enemyHP-1 , 0);
            body.GetComponent<SkinnedMeshRenderer>().material.SetFloat("_Damage", 1);
        }
    }
}
