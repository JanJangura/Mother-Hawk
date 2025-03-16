using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    private float timer;
    public float rateOfFire = 2;

    private EnemyMovement enemyScript;

    private void Start()
    {
        enemyScript = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer > rateOfFire)
        {
            timer = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        if (enemyScript && enemyScript.isDead) return;
        // Shooting Logic
        // To spawn object we use instantiate, the prefab, the position of spawn, then the rotation.
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    }    
}
