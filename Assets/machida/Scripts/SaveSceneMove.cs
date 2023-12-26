using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSceneMove : MonoBehaviour
{
    public void OnSaveButtonClick()
    {
        ItemBox.instance.itemBoxPanel.SetActive(false);
        // セーブ画面に切り替える
        SceneManager.LoadScene("SaveScene"); // "SaveScene"は適切なシーン名に変更
    }
}
