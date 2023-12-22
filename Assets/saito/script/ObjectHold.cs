using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHold : MonoBehaviour
{

    Transform hold;


    private void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            if (hold != null)
            {


                hold.SetParent(null);
                hold = null;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            if (hold == null && Input.GetKeyDown("space"))
            {
                other.transform.SetParent(this.transform);
                other.transform.localPosition = new Vector3(0, -2, 8);
                hold = other.transform;
            }

        }

    }

    // private void OnCollisionStay(Collision collision)
    // {
    //     if (collision.gameObject.tag == "Finish")
    //     {
    //         if (Input.GetKey("space"))
    //         {
    //             collision.transform.SetParent(this.transform);
    //             collision.transform.localPosition = new Vector3(0, -2, 8);
    //             hold = collision.transform;
    //         }

    //     }

    // }
}

