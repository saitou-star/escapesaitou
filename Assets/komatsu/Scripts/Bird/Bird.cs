using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // 完成したときに手に入るアイテム
    public int completeItemID;
    private GameObject BirdPanel;

    int completeNum = 0;


    public void OnUseItem()
    {
        completeNum++;

        if (completeNum >= 2)
        {
            Debug.Log("鳥が元気になった！");
            var item = ItemDatabase.instance.GetItem(completeItemID);
            ItemBox.instance.SetItem(item);
        }
    }

    public void OnFailed()
    {
        BirdPanel.SetActive(true);

        Debug.Log("変わらない…。");
    }
}
