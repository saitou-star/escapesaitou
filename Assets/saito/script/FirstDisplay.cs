using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FirstDisplay : MonoBehaviour
{

    public GameObject canvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Penguin")
        {
            canvas.SetActive(false);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Penguin")
        {
            canvas.SetActive(true);
        }
    }

}

