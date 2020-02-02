using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Game game;

    private bool InHand;

    public Animator anim;
    Rigidbody2D rb;
    Transform obj;

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

        if(Input.GetKeyDown(KeyCode.T))
        {
            if (this.transform.childCount != 0)
            {
                anim.SetTrigger("triggerpick");
                obj.parent = game.transform;
                //fragile so destroys
                if (obj.tag == "Fragile")
                {
                    Destroy(obj.gameObject);
                    InHand = false;
                }
                else
                {
                    StartCoroutine(WaitSec(1));
                    if (rb.velocity.x < -0.01)
                    {
                        obj.GetComponent<Rigidbody2D>().velocity += 3 * Vector2.left;
                    }
                    if (rb.velocity.x > 0.01)
                    {
                        obj.GetComponent<Rigidbody2D>().velocity += 3 * Vector2.right;
                    }
                    if (rb.velocity.y < -0.01)
                    {
                        obj.GetComponent<Rigidbody2D>().velocity += 3 * Vector2.down;
                    }
                    if (rb.velocity.y > 0.01)
                    {
                        obj.GetComponent<Rigidbody2D>().velocity += 3 * Vector2.up;
                    }
                }
            }
        }
    }

    private IEnumerator WaitSec(float wait)
    {
        yield return new WaitForSeconds(wait);
        obj.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        InHand = false;
    }

    void FixedUpdate()
    {
        float speed = 2.0f;
        rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * speed;
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Pickupable" || collision.tag == "Fragile")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger("triggerpick");
                if (collision.transform.parent == game.transform)
                {
                    if (InHand == false)
                    {
                        InHand = true;
                        Debug.Log(InHand);
                        Debug.Log(collision);
                        collision.transform.SetParent(this.transform);
                        obj = collision.transform;
                    }
                }
                else
                {
                    obj.parent = game.transform;
                    InHand = false;
                }
            }
        }
    }
}
