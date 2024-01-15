using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Camera miniMap;


    void Start()
    {
        miniMap.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && !miniMap)
        {
            miniMap.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.M) && miniMap)
        {
            miniMap.gameObject.SetActive(true);
        }

    }
}
