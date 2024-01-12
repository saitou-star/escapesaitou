using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bollre : MonoBehaviour
{
    public Button button;
    private Transform Bolltransform;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(OnButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnButtonClicked()
    {
        Transform Bolltransform = this.transform;
        Bolltransform.position = new Vector3(-8.5f, 1.25f, -7.74f);
    }
}
