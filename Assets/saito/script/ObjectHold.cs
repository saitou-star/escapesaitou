using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHold : MonoBehaviour
{
    Transform hold;
    bool push;
    GameObject[] Bucket_Ten;
    GameObject[] Bucket_Seven;
    GameObject[] Bucket_Three;
    int num10 = 10;
    int num7 = 0;
    int num3 = 0;


    void Start()
    {
        Bucket_Ten = new GameObject[]{
            GameObject.Find("WaterOne_ten"),
            GameObject.Find("WaterTwo_ten"),
            GameObject.Find("WaterThree_ten"),
            GameObject.Find("WaterFour_ten"),
            GameObject.Find("WaterFive_ten"),
            GameObject.Find("WaterSix_ten"),
            GameObject.Find("WaterSeven_ten"),
            GameObject.Find("WaterEight_ten"),
            GameObject.Find("WaterNine_ten"),
            GameObject.Find("WaterTen_ten")
        };

        Bucket_Seven = new GameObject[]{
            GameObject.Find("WaterOne_seven"),
            GameObject.Find("WaterTwo_seven"),
            GameObject.Find("WaterThree_seven"),
            GameObject.Find("WaterFour_seven"),
            GameObject.Find("WaterFive_seven"),
            GameObject.Find("WaterSix_seven"),
            GameObject.Find("WaterSeven_seven")
        };

        Bucket_Three = new GameObject[]{
            GameObject.Find("WaterOne_three"),
            GameObject.Find("WaterTwo_three"),
            GameObject.Find("WaterThree_three")
        };

    }

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
        if (other.gameObject.name == "Bucket_10")
        {
            if (hold == null && push)
            {
                other.transform.SetParent(this.transform);
                other.transform.localPosition = new Vector3(0, -2, 10);
                hold = other.transform;

            }
            else if (other.gameObject.name == "Bucket_07")
            {
                for (int i = 6; i > 0; i--)
                {
                    if (Bucket_Seven[i] == null)
                    {
                        continue;
                    }
                }


            }
            else if (other.gameObject.name == "Bucket_03")
            {

            }
        }
        else if (other.gameObject.name == "Bucket_07")
        {
            if (hold == null && push)
            {
                other.transform.SetParent(this.transform);
                other.transform.localPosition = new Vector3(0, -2, 10);
                hold = other.transform;
            }
        }
        else if (other.gameObject.name == "Bucket_03")
        {
            if (hold == null && push)
            {
                other.transform.SetParent(this.transform);
                other.transform.localPosition = new Vector3(0, -2, 10);
                hold = other.transform;
            }
        }
        else if (other.gameObject.name == "MagicPot")
        {
            if (hold == null && push)
            {
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

