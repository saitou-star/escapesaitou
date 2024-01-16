using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirePlace : MonoBehaviour
{
    
    bool isChange = false;

    [SerializeField]
    private  Image backgroundImage; // 最初の背景
    [SerializeField]
    private Sprite newBackgroundImage; // 新しい背景
    [SerializeField]
    private GameObject DownArrow; // 成功時に表示するUI
    [SerializeField]
    private AudioSource arrowSE; // 成功時SE
    
     int completeNum = 0;

     void Start()
     {
        completeNum = GameSaveData.Instance.GetGameFlag("FirePlaceItemUseCount");

        // セーブデータから状態を復帰させる
        // 暖炉に使用したアイテムが2個であったら背景を変更する
        if(completeNum >= 2)
        {
            ChangeBackground();
        }
     }

    // 画像を入れ替える
    public void ChangeBackground()
    {
        Debug.Log("ChangeBackground called!"); // デバッグメッセージを追加
        if(isChange) return;
        isChange = true;

        Debug.Log("OnOpen");
        
        backgroundImage.sprite = newBackgroundImage;
        DownArrow.SetActive(true);
        arrowSE.Play();

    }


    public void OnUseItem()
    {
        completeNum++;
        // 使用したアイテム自体ではなく、使ったアイテムの個数を記憶しておく
        GameSaveData.Instance.SetGameFlag("FirePlaceItemUseCount", completeNum);

        if(completeNum >= 2)
        {
            ChangeBackground();
            Debug.Log("成功。移動できます。");
        }
    }

    public void OnFailed()
    {
        Debug.Log("暖炉がある。暖炉の奥になにか階段のようなものがある。火が消せたら…。");
    }
}