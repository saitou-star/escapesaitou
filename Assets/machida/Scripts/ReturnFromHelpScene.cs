using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnFromHelpScene : MonoBehaviour
{
void Update()
{
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        // 前のSceneに戻る
        SceneManager.LoadScene("UI");//前のSceneの名前
    }
}
}