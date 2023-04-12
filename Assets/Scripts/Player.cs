using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] public int _HP = 10;
    private int _currentHP;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(_currentHP > _HP)
        {
            Debug.Log("test");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemies")
        {
            _HP--;
            _currentHP = _HP;
        }
        if (other.tag == "Object")
        {
            
        }
    }
}
