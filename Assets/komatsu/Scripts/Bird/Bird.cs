using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    private GameObject BirdPanel;

    int completeNum = 0;
    [SerializeField]
    private Image backgroundImage; // 最初の背景
    [SerializeField]
    private Sprite newBackgroundImage; // 新しい背景
    [SerializeField]
    private GameObject TresureBox; // 成功時に表示するUI
    bool isChange = false;



    public void OnUseItem()
    {
        completeNum++;

        if (completeNum >= 2)
        {
            Debug.Log("鳥が元気になった！");
            if (isChange) return;
            isChange = true;

            Debug.Log("画像変更");

            backgroundImage.sprite = newBackgroundImage;
            TresureBox.SetActive(true);

        }
    }

    public void OnFailed()
    {
        BirdPanel.SetActive(true);

        Debug.Log("変わらない…。");
    }
}
