using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{

    public int enemyHealth;
    public GameObject deathEffect;

	void Start ()
    {
		
	}
	

	void Update ()
    {
        if (enemyHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
	}

    public void GiveDamage(int damageToGive)
    {
        enemyHealth -= damageToGive;
    }
}
