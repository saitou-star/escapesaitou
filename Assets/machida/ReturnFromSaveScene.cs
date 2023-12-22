using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnFromSaveScene : MonoBehaviour
{
    public void OnSaveButtonClick()
    {
        // セーブ処理を呼ぶ
        // SaveManager.Instance.SaveGame();
    if (Input.GetButtonDown("Cancel"))
        {
            // クリック（またはスペースキー）時の処理を呼び出す
            SceneManager.LoadScene("UI");
        }
        // セーブ画面に切り替える
         // "SaveScene"は適切なシーン名に変更
    }
}
