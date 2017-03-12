using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public static int playerHealth;
    public int maxPlayerHealth;
    public bool isDead;

    LevelManager levelmanager;
    public Text healthText;


    void Start()
    {
        isDead = false;
        levelmanager = FindObjectOfType<LevelManager>();
        playerHealth = maxPlayerHealth;
	}


	void Update()
    {
        healthText.text = "" + playerHealth;    // Updates the player health GUI.

        if (playerHealth <= 0 && !isDead)   // If the players health is below zero, this respawns the player.
        {
            isDead = true;
            playerHealth = 0;
            levelmanager.RespawnPlayer();  
        }   
	}

    public static void DamagePlayer(int damageToGive)   // Receives damage from external sources.
    {
        playerHealth -= damageToGive;      
    }

    public void FullHealth()    // Refills the players health, called when respawning.
    {
        playerHealth = maxPlayerHealth;
    }
}
