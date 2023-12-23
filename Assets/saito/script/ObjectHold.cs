using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHold : MonoBehaviour
{
    Transform hold;
    bool push;
    bool pushenter;
    GameObject[] Bucket_Ten;
    GameObject[] Bucket_Seven;
    GameObject[] Bucket_Three;
    int num10;
    int num7;
    int num3;


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
        pushenter = Input.GetKeyDown("Return");

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
        for (int i = 9; i >= 0; i--)
        {
            if (Bucket_Ten[i] == null)
            {
                continue;
            }
            else if (Bucket_Ten[i] == true)
            {
                num10 = i;
            }
            else
            {
                num10 = 0;
            }
        }

        for (int i = 6; i >= 0; i--)
        {
            if (Bucket_Seven[i] == null)
            {
                continue;
            }
            else if (Bucket_Seven[i] == true)
            {
                num7 = i;
            }
            else
            {
                num7 = 0;
            }
        }

        for (int i = 2; i >= 0; i--)
        {
            if (Bucket_Seven[i] == null)
            {
                continue;
            }
            else if (Bucket_Three[i] == true)
            {
                num3 = i;
            }
            else
            {
                num3 = 0;
            }
        }


        if (hold == null && push)
        {
            if (other.gameObject.name == "Bucket_10")
            {
                other.transform.SetParent(this.transform);
                other.transform.localPosition = new Vector3(0, -2, 10);
                hold = other.transform;
            }
            else if (other.gameObject.name == "Bucket_07")
            {
                other.transform.SetParent(this.transform);
                other.transform.localPosition = new Vector3(0, -2, 10);
                hold = other.transform;
            }
            else if (other.gameObject.name == "Bucket_03")
            {
                other.transform.SetParent(this.transform);
                other.transform.localPosition = new Vector3(0, -2, 10);
                hold = other.transform;
            }
            else if (other.gameObject.name == "MagicPot")
            {
                other.transform.SetParent(this.transform);
                other.transform.localPosition = new Vector3(0, -2, 10);
                hold = other.transform;
            }
        }
        else if (hold != null && pushenter)
        {
            if (other.gameObject.name == "Bucket_10")
            {
                if (transform.Find("Bucket_07") != null && transform.Find("Bucket_03") == null)
                {



                }
                else if (transform.Find("Bucket_03") != null)
                {

                }

            }
            else if (other.gameObject.name == "Bucket_07")
            {
                if (transform.Find("Bucket_10") != null && transform.Find("Bucket_03") == null)
                {


                }
                else if (transform.Find("Bucket_03") != null)
                {

                }

            }
            else if (other.gameObject.name == "Bucket_03")
            {
                if (transform.Find("Bucket_07") != null && transform.Find("Bucket_10") == null)
                {


                }
                else if (transform.Find("Bucket_10") != null)
                {

                }

            }
        }

    }

}


// else if (other.gameObject.name == "Bucket_07")
// {
//     for (int i = 6; i > 0; i--)
//     {
//         if (Bucket_Seven[i] == null)
//         {
//             continue;
//         }
//     }
// }


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
// }