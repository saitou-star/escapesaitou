using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject EndTextObject;
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        EndTextObject.SetActive(true);

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
