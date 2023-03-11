using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    [Header("Boss Spawn")]
    public GameObject BossSpawnGameObject;

    [Header("LayerMasks")]
    public LayerMask bulletLayerMask;
    public LayerMask playGameObject;

    [Header("Movement")]
    public float speed;

    [Header("FirePoint")]
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public float FireRate;
    float nextFire;

    [Header("Health")]
    public int maxHealth;
    public int currentHealth;
    public HealthBar healthBar;

    [Header("Meat")]
    public MeatManager MM;

    int pt1 = 1;
    int pt2 = 2;
    int holder;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }  

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!PauseMenu.isPaused)
        {
            // Player Movement
            Movement();


            // Shooting
            if (Input.GetButton("Fire1") || Input.GetButton("Jump"))
            {
                Shoot();
            }
        }
    }

    void Movement() {
        Vector3 pos = transform.position;
        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Physics2D.IgnoreLayerCollision(3, 6);
        Physics2D.IgnoreLayerCollision(3, 8);
        Physics2D.IgnoreLayerCollision(3, 9);
        if (hitInfo.tag != null)
        {
            if (hitInfo.tag == "EnemyBullet" || hitInfo.tag == "Enemy")
            {
                DamageTaken(1);
            }

            
            if (hitInfo.tag == "Meat" )
            {
                if (currentHealth < maxHealth) 
                 {
                    
                    Heal(pt1);
                 }
                else
                {
                    MM.meatCount = MM.meatCount + pt1;
                }
            }
            if (hitInfo.tag == "Meat2")
            {
                if (currentHealth <= maxHealth)
                {
                    Heal(pt2);
                }
                else
                {
                    MM.meatCount = MM.meatCount + pt2;
                }
            }

            if(MM.meatCount >= 10)
            {
                BossSpawnGameObject.GetComponent<FinalBossSpawn>().enabled = true;
             // SceneManager.LoadScene("VictoryScreen");
            }
        }
    }

    void Heal(int health)
    {
        MM.meatCount = MM.meatCount + health;
        currentHealth = currentHealth + health;
        healthBar.SetHealth(currentHealth);
    }

    void DamageTaken(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Shoot()
    {
        float timer = Time.time;

        // Shooting Logic
        if(timer > nextFire)
        {
            nextFire = Time.time + FireRate;
            Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        }
        // To spawn object we use instantiate, the prefab, the position of spawn, then the rotation. 
    }

    void Death()
    {
        // Instatiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        Time.timeScale = 1f;
        SceneManager.LoadScene("DeathScreen");
    }
}
