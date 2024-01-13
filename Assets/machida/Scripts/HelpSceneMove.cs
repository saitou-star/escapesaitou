using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HelpSceneMove : MonoBehaviour
{
    public void OnHelpButtonClick()
    {
        ItemBox.instance.itemBoxPanel.SetActive(false);
        SceneManager.LoadScene("HelpScene");
        
    }
}
