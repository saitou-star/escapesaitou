using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
public class CodeController : MonoBehaviour
{
    [SerializeField]
    int[] Answer = { 7, 3, 5, 0 };

    [SerializeField]
    CodePanel[] codePanels = default;

    [SerializeField]
    private GameObject Panel;

    public void OnClickButton()
    {
        Debug.Log("ボタン検知");
        if (CheckClear())
        {
            Debug.Log("Clear");

            // 正解の場合、他のパネルを非アクティブにする
            ClosePanel();
        }
    }

    bool CheckClear()
    {
        for (int i = 0; i < codePanels.Length; i++)
        {
            if (codePanels[i].number != Answer[i])
            {
                Debug.Log($"Panel {i + 1} does not match. Expected: {Answer[i]}, Actual: {codePanels[i].number}");
                return false;
            }
        }
        return true;
    }

    void ClosePanel()
    {
        Panel.SetActive(false);
            
    }
}
