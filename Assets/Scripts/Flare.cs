using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Flare : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(0, 100, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 0) 
        {
            Destroy(gameObject);
        }
        if (transform.position.y >= 18)
        {
            gameObject.GetComponent<Rigidbody>().drag = 10;
        }
    }
}
