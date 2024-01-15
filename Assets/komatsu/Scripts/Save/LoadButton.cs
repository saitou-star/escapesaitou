using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadButton : MonoBehaviour
{
    // ロードボタンがクリックされたときにmeinステージへ移動後呼び出されるメソッド
    void Awake()
    {
        // GameSaveData クラスのインスタンスを取得
        GameSaveData gameSaveData = GameSaveData.Instance;

        // インスタンスが存在し、ロードメソッドがあれば呼び出す
        if (gameSaveData != null)
        {
            gameSaveData.Load();
            Debug.Log("ロードが完了しました。");
        }
        else
        {
            Debug.Log("GameSaveData インスタンスが見つかりません。");
        }
    }


}