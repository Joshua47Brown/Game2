using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public float respawnDelay;
    public GameObject currentCheckPoint;
    Player player;
    public PlayerHealthManager playerHealthManager;

    void Start ()
    {
        player = FindObjectOfType<Player>();
        playerHealthManager = FindObjectOfType<PlayerHealthManager>();
    }
	

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerCo());
    }

    public IEnumerator RespawnPlayerCo()
    {
        player.gameObject.SetActive(false);
        
        yield return new WaitForSeconds(respawnDelay);
        player.transform.position = currentCheckPoint.transform.position;
        Debug.Log("Player Respawned");
        player.gameObject.SetActive(true);
        playerHealthManager.FullHealth();
        playerHealthManager.isDead = false;
    }
}
