using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDetection : MonoBehaviour
{
    public GameObject enemyDetected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemies")
        {
            enemyDetected = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemies")
        {
            enemyDetected = null;
        }
    }
}
