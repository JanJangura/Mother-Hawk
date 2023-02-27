using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    [Header("Health")]
    public int maxHealth;
    public int currentHealth = 0;
    public HealthBar healthBar;

    [Header("Meat")]
    public GameObject meat;
    public Transform enemyPrefab;

    private Rigidbody2D rb;

    public static bool isDead;
    int tagChecker;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        tagChecker = this.gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "BelowScreen")
        {
            Destroy(this.gameObject);
        }
        else if(hitInfo.tag == "BossStage" && tagChecker == 10)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else if (hitInfo.tag == "Bullet")
        {
            DamageTaken(1);
        } 
    }

    private void DamageTaken(int damage)
    {
        currentHealth -= damage;
        
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            if(tagChecker == 10)
            {
                Destroy(this.gameObject); // Destroy current game object
                SceneManager.LoadScene("VictoryScreen");
            }
            else
            {
                isDead = true;
                Death();
            }
        }
    }

    void Death()
    {
        //Instatiate(deathEffect, transform.position, Quaternion.identity);
        Instantiate(meat, enemyPrefab.transform.position, Quaternion.identity);
        Destroy(this.gameObject); // Destroy current game object
    }
}
