using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.UI;

public class TresureBoxCodeControlller : MonoBehaviour
{
    [SerializeField]
    int[] Answer = { };

    [SerializeField]
    CodePanel[] codePanels = default;

    [SerializeField]
    private GameObject Panel;
    [SerializeField]
    private GameObject NewPanel;
    // [SerializeField]
    // Image img;

    [SerializeField]
    private GameObject getItem;

    [SerializeField]
    private AudioSource successSE;

    [SerializeField]
    private AudioSource failureSE;

    // [SerializeField]
    // private Sprite openSprite;  // 開いた後の画像



    public void OnClickButton()
    {
        Debug.Log("ボタン検知");
        if (CheckClear())
        {
            // 成功時のSEを再生
            if (successSE != null)
            {
                successSE.Play();
            }

            Debug.Log("Clear");

            // 正解の場合、他のパネルを非アクティブにする
            ClosePanel();
            ChangePanel();
            GetItem();
        }
    }

    bool CheckClear()
    {
        for (int i = 0; i < codePanels.Length; i++)
        {
            if (codePanels[i].number != Answer[i])
            {
                Debug.Log($"Panel {i + 1} 間違っています. Expected: {Answer[i]}, Actual: {codePanels[i].number}");
                // 成功時のSEを再生
                if (failureSE != null)
                {
                    failureSE.Play();

                }
                return false;

            }
        }
        return true;
    }

    void ClosePanel()
    {
        Panel.SetActive(false);

    }

    void ChangePanel()
    {
        NewPanel.SetActive(true);
    }

    void GetItem()
    {
        // img.sprite = openSprite;
        getItem.SetActive(true);
    }
}



