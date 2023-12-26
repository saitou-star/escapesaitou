using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject canvas;  // 変数名はアタッチする [Object] で変更する

    void Start()
    {

    }

    void Update()
    {
        canvas.SetActive(true);

    }


}
