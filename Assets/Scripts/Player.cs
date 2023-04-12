using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] public int _HP = 10;
    private int _currentHP;
    public GameObject bulletPrefab;
    private GameObject Heal;

    // Start is called before the first frame update
    void Start()
    {
        Heal = GameObject.Find("Soldier_body");
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
            Heal.GetComponent<SkinnedMeshRenderer>().material.SetFloat("_Healing", 1);
            Heal.GetComponent<SkinnedMeshRenderer>().material.SetColor("_DefaultColor", Color.red);
            _currentHP = _HP;
        }
    }
}
