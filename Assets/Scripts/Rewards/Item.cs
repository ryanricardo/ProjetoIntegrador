﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    enum TypeItem
    {
        JumpMore,
        TorchFire,
        DamageMore,
    }

    [Header("Atributtes Item;")]
    [SerializeField]private TypeItem        typeItem;
    [SerializeField]private float           ValueReward;
    [Header("Components")]
    [SerializeField]private PlayerController PlayerController;
    [SerializeField]private GameObject       TorchWeapon;

        
    void Start()
    {
        PlayerController = FindObjectOfType<PlayerController>();
    }
    
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            switch(typeItem)
            {
                case TypeItem.JumpMore:
                FindObjectOfType<PlayerController>().ForceJump += ValueReward;
                FindObjectOfType<Hud>().ReceiveItem("Jump + " , ValueReward);
                Destroy(gameObject, 0);
                break;
                
                case TypeItem.TorchFire:
                Instantiate(TorchWeapon, transform.position, Quaternion.identity);
                Destroy(gameObject, 0);
                break;

                case TypeItem.DamageMore:
                FindObjectOfType<PlayerController>().Damage += 2;
                FindObjectOfType<Hud>().ReceiveItem("Damage + " , ValueReward);
                Destroy(gameObject, 0);
                break;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            switch(typeItem)
            {
                case TypeItem.JumpMore:
                FindObjectOfType<PlayerController>().ForceJump += ValueReward;
                FindObjectOfType<Hud>().ReceiveItem("Jump + " , ValueReward);
                Destroy(gameObject, 0);
                break;
                

            }
        }

    }
}

