using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    private float offset = 0.4f;
    private GameObject player;
    private bool grabbed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            grabbed = !grabbed;
            //player.GetComponent<Player>().anim.SetTrigger("istrigger");
        }

        if (grabbed)
        {
            gameObject.transform.SetParent(player.transform);
        }
        else if(!grabbed)
        {
            gameObject.transform.parent = null;
            player = null;
        }


    }



    public void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            player = coll.gameObject;
            
        }
          
    }

}
