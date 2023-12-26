using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnTriggerEnter : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
{
      Debug.Log(collision.gameObject.name); // ぶつかった相手の名前を取得
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
