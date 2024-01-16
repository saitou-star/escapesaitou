using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel0Loader : MonoBehaviour
{
    [SerializeField]
    GameObject UpArrow;

    // Start is called before the first frame update
    void Start()
    {   
        if(GameSaveData.Instance.CheckGameFlag("Panel0PassKeyCorrect", 1))
        {
            UpArrow.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
