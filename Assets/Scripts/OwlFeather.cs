using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlFeather : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public float timer = 5;

    private void Awake()
    {
        StartCoroutine(waiter());
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = -transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)       // Whenever a gameobject enters a zone. We want to add Collider2D, this will store information of what we hit. 
    {
        if (hitInfo.tag == "Player" || hitInfo.tag == "BelowScreen" || hitInfo.tag == "AboveScreen")
        {
            Destroy(gameObject);
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(timer);
        Object.Destroy(this.gameObject);
    }
}
