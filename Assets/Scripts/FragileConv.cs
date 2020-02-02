using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragileConv : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("here");
        if (coll.gameObject.tag == "Player" && coll.gameObject.GetComponentInChildren<Transform>().tag == "Fragile")
        {
            coll.gameObject.GetComponentInChildren<Transform>().parent = coll.gameObject.GetComponentInParent<Game>().transform;
            coll.gameObject.GetComponentInChildren<Transform>().position = new Vector3((gameObject.transform.position.x + 0.5f), (gameObject.transform.position.y + 2f), gameObject.transform.position.z);
        }
    }
}
