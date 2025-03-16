using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFeathers : MonoBehaviour
{
    public float timer = 2;
    public GameObject feathers;
    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(timer);
        Object.Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Enemy")
        {
            EnemyMovement enemy = hitInfo.GetComponent<EnemyMovement>();
            if (enemy != null)
            {
                if (!enemy.isDead) Destroy(this.gameObject);
                else return;
            }
        }       
        if (hitInfo.tag == "BelowScreen" || hitInfo.tag == "AboveScreen")
        {
            Destroy(this.gameObject);
        }
    }
}
