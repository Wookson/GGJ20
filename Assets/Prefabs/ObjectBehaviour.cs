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
            
        }

        if (grabbed)
        {
            gameObject.transform.SetParent(player.transform);
            //gameObject.transform.position = new Vector2(player.transform.position.x + offset, player.transform.position.y);
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
