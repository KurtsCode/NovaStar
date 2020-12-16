﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthAndDamage : MonoBehaviour
{
    [SerializeField]
    public float health = 1;
    [SerializeField]
    public float maximumHealth = 1;

    [SerializeField]
    private GameObject _explosionAnim;

    private PlayerWeaponsFire _playerWeapon;
    private SpawnManager _spawnManager;
    private void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("Missing Spawn Manager");
        }

        _playerWeapon = GameObject.Find("Player").GetComponent<PlayerWeaponsFire>();
        if (_playerWeapon == null)
        {
            Debug.LogError("Player Weapon is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PlayerDamage()
    {
        if (_playerWeapon._weaponPowerLevel > 0)
        {
            _playerWeapon._weaponPowerLevel --;
            _playerWeapon.UpdateWeaponLevel();
        }
        else if (_playerWeapon._weaponPowerLevel == 0)
        {
            health -= .5f;
        }

        if (health <= 0)
        {
            health = 1f; //keep in here, used for checkpoint system to reset player health
            this.gameObject.SetActive(false); //inactive to prevent damage or input
            Instantiate(_explosionAnim, transform.position, Quaternion.identity);
        }
    }

    //for testing
    public void PlayerDamageTest()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            PlayerDamage();
            //Debug.Log("Health= " + health);
        }
    }

    public bool getPlayerStatus()
    {
        return this.gameObject.activeSelf;
    }
}

