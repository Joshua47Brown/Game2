using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed;
    public Player player;

    private Sprite defaultSprite;
    public Sprite muzzleFlash;
    public float framesToFlash;

    private SpriteRenderer spriteRend;
    CameraController camCtrl;

    public GameObject deathParticle;
    public GameObject bulletParticle;

    public int damageToGive;


    void Start()
    {
        camCtrl = FindObjectOfType<CameraController>();
        spriteRend = GetComponent<SpriteRenderer>();
        defaultSprite = spriteRend.sprite;
        player = FindObjectOfType<Player>();
        GetComponent<Rigidbody2D>().rotation = Random.Range(-5, 5);

        if (player.transform.localScale.x < 0) // Flips the bullets relative to player. 
        {
            speed = -speed;
            transform.localScale = new Vector3(-1, 1, 1);
            GetComponent<Rigidbody2D>().rotation = Random.Range(-5, 5);
        }

        StartCoroutine("MuzzleFlashCo");
	}
	

	void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }

        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        Destroy(gameObject, 3.0f);
    }


    IEnumerator MuzzleFlashCo() // Sets first few frames of the bullet object to muzzle flash sprite.
    {
        spriteRend.sprite = muzzleFlash;
        for (int i = 0; i < framesToFlash; i++) // Countdown timer.
        {
            yield return 0;
        }
        spriteRend.sprite = defaultSprite;
    }


    void OnTriggerEnter2D(Collider2D other) // Handles the bullet's collsions.
    {
        if (other.tag != "Bullet" || other.tag != "Player" || other.tag != "Checkpoint" || other.tag != "Ground Collision" || other.tag != "NPC")
        {
            if (other.tag == "Ground Collision")
            {
                Debug.Log("hitting ground coll");
            }
            Debug.Log("Ehhhhhhhh");
            if (other.tag == "Enemy")
            {
                Debug.Log("hitting enemy");
                other.GetComponent<EnemyHealthManager>().GiveDamage(damageToGive);
            }
            else
            {
                if (other.tag != "Ground Collision" && other.tag != "Checkpoint" && other.tag != "NPC" && other.tag != "Player" && other.tag != "Bullet")
                {
                    Debug.Log("oh my");
                    Instantiate(bulletParticle, gameObject.transform.position, gameObject.transform.rotation);
                    Destroy(gameObject);
                } 
            }
        }
    }
}
