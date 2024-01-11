using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject MenuObject;
    [SerializeField] GameObject HelpScreen;
    bool menuState;
    bool helpState;

    // Update is called once per frame
    void Update()
    {
        if (menuState == false)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                MenuObject.gameObject.SetActive(true);
                menuState = true;
                // マウスカーソルを表示にし、位置固定解除
                // Cursor.visible = true;
                // Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            if (Input.GetButtonDown("Cancel"))
            {
                MenuObject.gameObject.SetActive(false);
                menuState = false;
                // マウスカーソルを非表示にし、位置を固定
                // Cursor.visible = false;
                // Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}