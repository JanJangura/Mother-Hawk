using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Movement Speed")]
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "BelowScreen" || hitInfo.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
