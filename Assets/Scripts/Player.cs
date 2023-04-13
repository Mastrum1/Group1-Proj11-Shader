using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] public int _HP = 10;
    private int _currentHP;
    public GameObject bulletPrefab;
    private GameObject Heal;
    private GameObject Spawn;
    private bool _isSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        Heal = GameObject.Find("Soldier_body");
        Spawn = GameObject.Find("Soldier_body");
    }

    // Update is called once per frame
    void Update()
    {
        _isSpawn = true;
        if (_isSpawn == true)
        {
            Spawn.GetComponent<SkinnedMeshRenderer>().material.SetFloat("_Spawn", 1);
            Spawn.GetComponent<SkinnedMeshRenderer>().material.SetColor("_DefaultColor", Color.white * 120);
            _isSpawn = false;
        }
        if (_HP <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemies")
        {
            _HP--;
            Heal.GetComponent<SkinnedMeshRenderer>().material.SetFloat("_Healing", 1);
            Heal.GetComponent<SkinnedMeshRenderer>().material.SetColor("_DefaultColor", Color.red * 120);
            _currentHP = _HP;
        }
    }
}
