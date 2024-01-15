using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    [SerializeField]
    private GameObject BirdHintPanel;

    int completeNum = 0;
    [SerializeField]
    private Image backgroundImage; // 最初の背景
    [SerializeField]
    private Sprite newBackgroundImage; // 新しい背景
    [SerializeField]
    private GameObject TresureBox; // 成功時に表示するUI
    bool isChange = false;
    private bool isFailedPanelActive = false; // パネルがアクティブかどうかを示すフラグ


     void Start()
     {
        completeNum = GameSaveData.Instance.GetGameFlag("BirdItemUseCount");

        // セーブデータから状態を復帰させる
        // 鳥に使用したアイテムが2個であったら背景を変更する
        if(completeNum >= 2)
        {
            ChangeBird();
        }
     }



    public void OnUseItem()
    {
        completeNum++;
        // 使用したアイテム自体ではなく、使ったアイテムの個数を記憶しておく
        GameSaveData.Instance.SetGameFlag("BirdItemUseCount", completeNum);
        if (completeNum >= 2)
        {
            Debug.Log("鳥が元気になった！");
            if (isChange) return;
            isChange = true;

            Debug.Log("画像変更");
            ChangeBird();

        }





    }

    public void OnFailed()
    {
        if (!isFailedPanelActive)
        {
            BirdHintPanel.SetActive(true);
            Debug.Log("変わらない…。");
            isFailedPanelActive = true; // 初回の呼び出しでフラグをtrueに設定
        }
        else
        {
            BirdHintPanel.SetActive(false); // 2回目以降は非表示にするだけ
        }
    }

    public void ChangeBird()
    {
            backgroundImage.sprite = newBackgroundImage;
            TresureBox.SetActive(true);
            BirdHintPanel.SetActive(false);
    }
}