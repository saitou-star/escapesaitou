using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Save(GameObject obj)
    {
        ES3.Save("8931440161498490141", obj);
    }
    public void Load()
    {
        GameObject obj = ES3.Load<GameObject>("8931440161498490141");
        Instantiate(obj);
        Debug.Log(obj);
    }
}
