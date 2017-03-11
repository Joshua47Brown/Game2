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

    // Use this for initialization
    void Start ()
    {
        FindObjectOfType<SpriteRenderer>();
        player = FindObjectOfType<Player>();

        spriteRend = player.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && isTakingDamage == false) //getting called too often
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
        spriteRend.color = hitColor;
        yield return new WaitForSeconds(0.1f);
        spriteRend.color = normalColor;
    }
}
