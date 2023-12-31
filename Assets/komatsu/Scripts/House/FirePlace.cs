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
    
     int completeNum = 0;

    // 画像を入れ替える
    public void ChangeBackground()
    {
        Debug.Log("ChangeBackground called!"); // デバッグメッセージを追加
        if(isChange) return;
        isChange = true;

        Debug.Log("OnOpen");
        
        backgroundImage.sprite = newBackgroundImage;
        DownArrow.SetActive(true);
        
    }


    public void OnUseItem()
    {
        completeNum++;
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