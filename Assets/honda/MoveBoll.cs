using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var body = GameObject.Find("Boll").GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.UpArrow))
        {
            body.WakeUp();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            body.WakeUp();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            body.WakeUp();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.WakeUp();
        }
    }
}
