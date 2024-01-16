using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideScript : MonoBehaviour
{
    public Text text;
    public float delay = 3f;
    void Start()
    {
        Invoke("Destroy", delay);
    }

    void Destroy()
    {
        Destroy(text);
    }
}
