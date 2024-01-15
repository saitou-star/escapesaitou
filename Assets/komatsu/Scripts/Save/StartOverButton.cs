using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOverButton : MonoBehaviour
{
    public void OnStartOverButtonClicked()
    {
        // GameSaveData.Instance が null でないことを確認
        if (GameSaveData.Instance != null)
        {
            // はじめからボタンがクリックされたときに呼ばれるメソッド
            GameSaveData.Instance.InitializeSaveData();

        }
    }
}

