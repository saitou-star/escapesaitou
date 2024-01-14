using UnityEngine;
using UnityEngine.UI;

public class SaveButton : MonoBehaviour
{
    // セーブボタンがクリックされたときに呼び出されるメソッド
    public void OnSaveButtonClicked()
    {
        // GameSaveData クラスのインスタンスを取得
        GameSaveData gameSaveData = GameSaveData.Instance;

        // インスタンスが存在し、セーブメソッドがあれば呼び出す
        if (gameSaveData != null)
        {
            gameSaveData.Save();
            Debug.Log("セーブが完了しました。");
        }
        else
        {
            Debug.LogError("GameSaveData インスタンスが見つかりません。");
        }
    }
}
