using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinManager : MonoBehaviour
{
    public GameObject clearOb;
    public GameObject startOb;
    public GameObject player;
    public Canvas popWindow;

    void Start()
    {
        clearOb.gameObject.SetActive(false);
    }

    void Update()
    {

    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == player)
        {
            popWindow.gameObject.SetActive(true);
            clearOb.gameObject.SetActive(true);
            startOb.gameObject.SetActive(false);
        }
    }

    void OnCollisionExit(Collision other)
    {
        popWindow.gameObject.SetActive(false);
    }
}
