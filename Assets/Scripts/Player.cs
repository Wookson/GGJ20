using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject UIBk;

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

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (UIBk.activeSelf == false)
            {
                UIBk.SetActive(true);
            }
            else if (UIBk.activeSelf == true)
            {
                UIBk.SetActive(false);
            }
        }
    }

    void FixedUpdate()
    {
        float speed = 2.0f;
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
    }
}
