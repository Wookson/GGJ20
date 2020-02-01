using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Animator anim;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("xspeed", rb.velocity.x);
        anim.SetFloat("yspeed", rb.velocity.y);

        if (rb.velocity.magnitude < 0.01)
            anim.speed = 0.0f;
        else
            anim.speed = 1.0f;
    }

    void FixedUpdate()
    {
        float speed = 2.0f;
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
    }
}
