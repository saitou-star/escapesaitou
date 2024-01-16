using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera Subcam1, Subcam2;

    // Start is called before the first frame update
    void Start()
    {
        Subcam1.enabled = true;
        Subcam2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CameraChange()
    {
        if (Subcam1.enabled == true)
        {
            Subcam1.enabled = false;
            Subcam2.enabled = true;
        }
        else
        {
            Subcam2.enabled = false;
            Subcam1.enabled = true;
        }


    }
}
