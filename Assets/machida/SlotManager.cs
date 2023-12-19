using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public GameObject[] cubeArray = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("F1"))
        {
        cubeArray[0].gameObject.GetComponent<Renderer> ().material.color = Color.red;
        }
    }
}
