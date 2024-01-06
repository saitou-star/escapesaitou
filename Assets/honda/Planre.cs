using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planre : MonoBehaviour
{
    public Button button;
    public Transform targetObject;

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
        Quaternion myRotation = transform.rotation;
        // Transform rotation = target.transform.rotation;
        // Plantransform.rotation = Quaternion.Euler(0f, 0f, 0f);
        // targetObject.Rotate(new Vector3(0f, 0f, 0f));
        targetObject.localEulerAngles = Vector3.zero;
        Debug.Log("Click");
    }
}
