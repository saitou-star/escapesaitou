using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoad : MonoBehaviour
{
    private float cubeSpeed = 3.0f;
    private float autoSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * cubeSpeed;
        float moveZ = Input.GetAxis("Vertical") * Time.deltaTime * cubeSpeed;
        transform.position = new Vector3(
            transform.position.x + moveX, transform.position.y, transform.position.z + moveZ
        );
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Plane1")
        {
            transform.position = new Vector3(
                transform.position.x + autoSpeed, 0.5f, transform.position.z
            );
        }
    }
}
