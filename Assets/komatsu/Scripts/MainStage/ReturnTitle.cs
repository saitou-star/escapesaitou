using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnTitle : MonoBehaviour
{
    public void OnLoadButtonClick()
    {
        // シーンをロードする前にDontDestroyOnLoadでマークしたオブジェクトを破棄
        ItemBox itemBoxInstance = ItemBox.instance;
        if (itemBoxInstance != null)
        {
            Destroy(itemBoxInstance.gameObject);
        }

        SceneManager.LoadScene("Title");
    }
}

