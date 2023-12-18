using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSceneMove : MonoBehaviour
{
    public void OnSaveButtonClick()
    {
        // セーブ処理を呼ぶ
        // SaveManager.Instance.SaveGame();

        // セーブ画面に切り替える
        SceneManager.LoadScene("SaveScene"); // "SaveScene"は適切なシーン名に変更
    }
}
