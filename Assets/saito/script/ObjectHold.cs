using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHold : MonoBehaviour
{

    Transform hold;
    bool push;

    private void Update()
    {
        push = Input.GetKeyDown("space");

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
            if (hold == null && push)
            {
                Debug.Log(other.gameObject.name);
                other.transform.SetParent(this.transform);
                other.transform.localPosition = new Vector3(0, -2, 10);
                hold = other.transform;
            }
        }
    }


    // public GameObject WaterSeven;
    // private void OnTriggerStay(Collider other)
    // {
    //     if (other.gameObject.tag == "Finish")
    //     {
    //         if (Input.GetKeyDown("enter"))
    //         {
    //             WaterSeven.SetActive(false);
    //         }
    //     }
    // }

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

