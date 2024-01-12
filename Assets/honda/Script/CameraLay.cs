using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLay : MonoBehaviour
{
    public Camera Subcam1, Subcam2, Subcam3, Subcam4, Subcam5, Subcam6;

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
        Subcam3.enabled = false;
        Subcam4.enabled = false;
        Subcam5.enabled = false;
        Subcam6.enabled = false;
    }
    public void CameraChange1()
    {
        Subcam1.enabled = false;
        Subcam2.enabled = true;
        Subcam3.enabled = false;
        Subcam4.enabled = false;
        Subcam5.enabled = false;
        Subcam6.enabled = false;
    }
    public void CameraChange2()
    {
        Subcam1.enabled = false;
        Subcam2.enabled = false;
        Subcam3.enabled = true;
        Subcam4.enabled = false;
        Subcam5.enabled = false;
        Subcam6.enabled = false;
    }
    public void CameraChange3()
    {
        Subcam1.enabled = false;
        Subcam2.enabled = false;
        Subcam3.enabled = false;
        Subcam4.enabled = true;
        Subcam5.enabled = false;
        Subcam6.enabled = false;
    }
    public void CameraChange4()
    {
        Subcam1.enabled = false;
        Subcam2.enabled = false;
        Subcam3.enabled = false;
        Subcam4.enabled = false;
        Subcam5.enabled = true;
        Subcam6.enabled = false;
    }
    public void CameraChange5()
    {
        Subcam1.enabled = false;
        Subcam2.enabled = false;
        Subcam3.enabled = false;
        Subcam4.enabled = false;
        Subcam5.enabled = false;
        Subcam6.enabled = true;
    }
}
