using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByPassScript : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D onHit)
    {
        Physics2D.IgnoreLayerCollision(6, 8);
        if (onHit != null)
        {
            if (onHit.tag == "ByPass")
            {
                enemyPrefab.GetComponent<EnemyFire>().enabled = false;
            }
        }
    }
}
