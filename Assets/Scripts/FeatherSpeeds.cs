using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeatherSpeeds : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    // Right when the bullet spawns we want it to fly forward in the direction is spawnned in.
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }
}
