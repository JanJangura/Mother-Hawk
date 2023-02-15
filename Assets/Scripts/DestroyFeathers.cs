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
        if (hitInfo.tag == "Enemy" || hitInfo.tag == "BelowScreen" || hitInfo.tag == "AboveScreen")
        {
            Destroy(gameObject);
        }       
    }
}
