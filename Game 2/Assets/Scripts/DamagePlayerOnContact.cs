using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayerOnContact : MonoBehaviour
{

    public int damageToGive;
    public bool isTakingDamage;
    public bool canTakeDamage;

    public SpriteRenderer spriteRend;
    public Color normalColor;
    public Color hitColor;
    PlayerHealthManager playerHealthManager;


    void Start()
    {
        playerHealthManager = FindObjectOfType<PlayerHealthManager>();
        spriteRend = FindObjectOfType<SpriteRenderer>();
        canTakeDamage = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.tag == "Player" && playerHealthManager.isDead == false)
        {
            PlayerHealthManager.DamagePlayer(damageToGive);
            playerHealthManager.PlayerHit();     
        }  
    }
}
