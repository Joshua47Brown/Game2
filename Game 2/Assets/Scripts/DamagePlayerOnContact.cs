using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayerOnContact : MonoBehaviour
{

    public int damageToGive;
    public bool isTakingDamage;
    public bool canTakeDamage;

    Player player;
    public SpriteRenderer spriteRend;
    public Color normalColor;
    public Color hitColor;
    PlayerHealthManager playerHealthManager;


    void Start()
    {
        playerHealthManager = FindObjectOfType<PlayerHealthManager>();
        player = FindObjectOfType<Player>();
        spriteRend = FindObjectOfType<SpriteRenderer>();
        canTakeDamage = true;
    }


	void Update()
    {
        if (player == null)  // If the player becomes null, this finds it again.
        {
            Debug.Log("player is null on damageoncontact");
            player = FindObjectOfType<Player>();
        }

        if (canTakeDamage)
        {
            //Physics2D.IgnoreLayerCollision(9, 10, false);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(9, 10, true);
        }
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("triggered");
        if (other.tag == "Player" && playerHealthManager.isDead == false)    // Getting called too often.
        {
            Debug.Log("firt tingo man");
            if (canTakeDamage == true) //makes the player open to attack
            {
                canTakeDamage = false;
                Debug.Log("taking damage");
                PlayerHealthManager.DamagePlayer(damageToGive);
                StartCoroutine(HitDelayCo());
            }        
        }  
    }

    public IEnumerator HitDelayCo() 
    {
        Debug.Log("HitDelayCo called");
        canTakeDamage = false;
        Physics2D.IgnoreLayerCollision(9, 10, true);
        StartCoroutine(FlickerCo());
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreLayerCollision(9, 10, false);
        canTakeDamage = true;
    }

    public IEnumerator FlickerCo()
    {
        Debug.Log("FlickerCo");
        player.GetComponent<SpriteRenderer>().color = hitColor;
        yield return new WaitForSeconds(0.1f);
        player.GetComponent<SpriteRenderer>().color = normalColor;
    }
}
