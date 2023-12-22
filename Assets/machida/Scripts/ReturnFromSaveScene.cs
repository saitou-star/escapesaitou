using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnFromSaveScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ItemBox.instance.itemBoxPanel.SetActive(true);
            SceneManager.LoadScene("UI");
        }
    }
}