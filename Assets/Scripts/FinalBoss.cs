using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    [Header("Scripts")]
    public EnemyMovement EM;

    private void OnTriggerEnter2D(Collider2D onHit)
    {
        Physics2D.IgnoreLayerCollision(6, 8);
        if (onHit != null)
        {
            if (onHit.tag == "BossStage")
            {
                EM.speed = 0;               
            }
        }
    }
}
