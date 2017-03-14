using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{

    public int enemyHealth;
    public GameObject deathEffect;
    public Material whiteFlash;
    public Material defaultMaterial;
    public float flashTime;


	void Update()
    {
        if (enemyHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
	}

    public void GiveDamage(int damageToGive)
    {
        StartCoroutine(EnemyFlash());
        enemyHealth -= damageToGive;
    }

    public IEnumerator EnemyFlash()
    {
        gameObject.GetComponent<SpriteRenderer>().material = whiteFlash;
        yield return new WaitForSeconds(flashTime);
        gameObject.GetComponent<SpriteRenderer>().material = defaultMaterial;
    }
}
