using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    public static int playerHealth;
    public int maxPlayerHealth;
    public bool isDead;

    //SpriteRenderer spriteRenderer;
    LevelManager levelmanager;
    public Text healthText;
    public bool canPlayerTakeDamage;

    public Color PlayerNormalColor;
    public Color PlayerHitColor;
    Player player;

    void Start()
    {
        isDead = false;
        canPlayerTakeDamage = true;
        player = FindObjectOfType<Player>();
        //spriteRenderer = FindObjectOfType<SpriteRenderer>();
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

    public void PlayerHit()    // Called from another script.      
    {
        if (isDead == false)    
        {
            Debug.Log("isDead = false");
            canPlayerTakeDamage = false;
            StartCoroutine(PlayerIsHitCo());           
        }
    }

    public IEnumerator PlayerIsHitCo()    // Starts a delay in which the player can't be hit.       
    {
        StartCoroutine(StartPlayerFlickeringCo());
        canPlayerTakeDamage = false;
        Physics2D.IgnoreLayerCollision(9, 10, true);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreLayerCollision(9, 10, false);
        canPlayerTakeDamage = true;
    }

    public IEnumerator StartPlayerFlickeringCo()    // Makes the player flash red for a short period of time.
    {
        player.GetComponent<SpriteRenderer>().color = PlayerHitColor;
        yield return new WaitForSeconds(0.1f);
        player.GetComponent<SpriteRenderer>().color = PlayerNormalColor;
    }
}
