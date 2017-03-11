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


    // Use this for initialization
    void Start ()
    {
        isDead = false;
        levelmanager = FindObjectOfType<LevelManager>();
        playerHealth = maxPlayerHealth;
        
	}

	// Update is called once per frame
	void Update ()
    {
        healthText.text = "" + playerHealth;

        if (playerHealth <= 0 && !isDead)
        {
            isDead = true;
            playerHealth = 0;
            levelmanager.RespawnPlayer();
            
        }
        
        
	}

    public static void DamagePlayer(int damageToGive)
    {
        playerHealth -= damageToGive;
        
    }

    public void FullHealth()
    {
        playerHealth = maxPlayerHealth;
    }
}
