using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheak : MonoBehaviour
{
    MeshRenderer Mesh;

    // Start is called before the first frame update
    void Start()
    {
        Mesh = GetComponent<MeshRenderer>();
        Debug.Log(Mesh.bounds.size);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
