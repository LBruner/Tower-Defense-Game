using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHealth = 10f;   
    [SerializeField] Text healthTxt;

    private void Start()
    {
        UpdateUI(playerHealth, healthTxt);
    }

    public void PlayerDamage(float damage)
    {
        playerHealth -= damage;
        UpdateUI(playerHealth, healthTxt);
    }

    public void UpdateUI(float number, Text gameobject)
    {
        gameobject.text = number.ToString();
    }
}
