using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    float speed = 3.0f;
    // float upForce = 100f;
    [SerializeField] GameObject parentObj;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        parentObj = GameObject.Find("GameObject");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = -transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = transform.right * speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = -transform.right * speed;
        }
        // if (Input.GetMouseButtonDown(0))
        //     rb.AddForce(new Vector3(0, upForce, 0));
    }
}
