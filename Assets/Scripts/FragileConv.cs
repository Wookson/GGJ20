using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileConv : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Fragile")
        {
            coll.gameObject.transform.position = new Vector3((gameObject.transform.position.x + 0.5f), (gameObject.transform.position.y + 2f), gameObject.transform.position.z);
        }
    }
}
