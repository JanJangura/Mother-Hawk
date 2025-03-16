using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public GameObject enemyGO;

    [Header("Health")]
    public int maxHealth;
    public int currentHealth = 0;
    public HealthBar healthBar;

    [Header("Meat")]
    public GameObject meat;
    public Transform enemyPrefab;

    [Header("SoundEffects")]
    private AudioSource EnemySoundSource;
    public AudioClip[] hitEffects;
    public AudioClip[] deathEffects;

    private Rigidbody2D rb;

    public bool isDead;
    int tagChecker;

    // Start is called before the first frame update
    void Start()
    {
        EnemySoundSource = GetComponent<AudioSource>();

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
        if (isDead) return; 
  
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            if(tagChecker == 10)
            {
                BossDeath();
            }
            else
            {
                Death();
            }
        }
        else
        {
            PlaySoundEffect(hitEffects, false);
        }
    }

    void Death()
    {
        //Instatiate(deathEffect, transform.position, Quaternion.identity);
        Instantiate(meat, enemyPrefab.transform.position, Quaternion.identity);
        if (deathEffects.Length == 0) Destroy(this.gameObject); // Destroy current game object
        else PlaySoundEffect(deathEffects, true);
    }

    void BossDeath()
    {
        Destroy(this.gameObject); // Destroy current game object
        SceneManager.LoadScene("VictoryScreen");
    }

    void PlaySoundEffect(AudioClip[] audioClips, bool isDeath)
    {
        isDead = isDeath;
        if (audioClips.Length > 0 && EnemySoundSource)
        {
            System.Random rng = new System.Random();
            int randomIndex = rng.Next(0, audioClips.Length); // Picks a random number
            EnemySoundSource.clip = audioClips[randomIndex];
            EnemySoundSource.Play();

            if(isDead) Destroy(this.gameObject, audioClips[randomIndex].length); 
        }
    }
}
