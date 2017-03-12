using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagePlayerOnContact : MonoBehaviour
{

    public int damageToGive;
    public bool isTakingDamage;

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
    }


	void Update()
    {
        if(player == null)  // If the player becomes null, this finds it again.
        {
            Debug.Log("player is null on damageoncontact");
            player = FindObjectOfType<Player>();
        }
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && isTakingDamage == false && playerHealthManager.isDead == false)    // Getting called too often.
        {
            StartCoroutine(HitDelayCo());
            PlayerHealthManager.DamagePlayer(damageToGive);
        }
    }

    public IEnumerator HitDelayCo() 
    {
        StartCoroutine(FlickerCo());
        isTakingDamage = true;
        yield return new WaitForSeconds(0.5f);
        isTakingDamage = false;
    }

    public IEnumerator FlickerCo()
    {
        player.GetComponent<SpriteRenderer>().color = hitColor;
        yield return new WaitForSeconds(0.1f);
        player.GetComponent<SpriteRenderer>().color = normalColor;
    }
}
