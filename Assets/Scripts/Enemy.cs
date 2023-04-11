using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int enemyHP = 3;
    private Renderer shaders = new Renderer();

    private float dissolve;
    // Start is called before the first frame update
    void Start()
    {
        shaders = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHP != 0)
        {
            if(dissolve < 0.99f) {
                dissolve = Mathf.Lerp(dissolve, 1f, 2f * Time.deltaTime);
            }
            else
            {
                dissolve = 1;
            }
            shaders.material.SetFloat("_Boolean", 1);
            shaders.material.SetFloat("_disolve", Mathf.Lerp(dissolve, 0, 2f * Time.deltaTime));

        }
        if (enemyHP == 0)
        {
            tag = "dead";
            if (dissolve > 0.01f)
            {
                dissolve = Mathf.Lerp(dissolve, 0f, 2f * Time.deltaTime);
                shaders.material.SetFloat("_Boolean", 0);
                shaders.material.SetFloat("_disolve", Mathf.Lerp(dissolve, 0, 2f * Time.deltaTime));
            }
        }
        if (enemyHP == 0 && dissolve <= 0.01f) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet") 
        {
            enemyHP= Math.Max(enemyHP-1 , 0);
        }
    }
}
