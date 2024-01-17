using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endeing : MonoBehaviour
{
    public Camera Subcam1,Subcam2 ;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CameraChange()
    {
        Subcam1.enabled = true;
        Subcam2.enabled = false;
       
    }
    public void CameraChange1()
    {
        Subcam1.enabled = false;
        Subcam2.enabled = true;
      
    }
}
