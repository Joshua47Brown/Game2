using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public float respawnDelay;
    public GameObject currentCheckPoint;
    Player player;
    public PlayerHealthManager playerHealthManager;

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerHealthManager = FindObjectOfType<PlayerHealthManager>();
    }

    void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }
    }
	

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerCo());
    }

    public IEnumerator RespawnPlayerCo()
    {
        Physics2D.IgnoreLayerCollision(9, 10, false);
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        player.transform.position = currentCheckPoint.transform.position;
        Debug.Log("Player Respawned");
        Physics2D.IgnoreLayerCollision(9, 10, false);
        player.gameObject.SetActive(true);   
        playerHealthManager.FullHealth();
        playerHealthManager.isDead = false;
    }
}
