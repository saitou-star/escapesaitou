using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadButton : MonoBehaviour
{
    public void OnLoadButtonClicked()
    {
        // GameSaveData.Instance が null でないことを確認
        if (GameSaveData.Instance.Load())
        {

            SceneManager.LoadScene("MainStage");
        }
        else
        {
            SceneManager.LoadScene("Title");
        }
    }

}