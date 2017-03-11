using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{

    Player player;
    LevelManager levelManager;
   
	void Start ()
    {
        levelManager = FindObjectOfType<LevelManager>();
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.SetActive(false);
            
            levelManager.RespawnPlayer();
        }
    }
}
