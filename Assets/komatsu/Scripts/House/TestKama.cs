using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class TestKama : MonoBehaviour
{
    // 完成したときに手に入るアイテム
    public int completeItemID;

    int completeNum = 0;

    [SerializeField]
    private GameObject KamaHintPanel;

    [SerializeField]
    private AudioClip completeSE;


    public void OnUseItem()
    {
        completeNum++;

        if (completeNum >= 3)
        {
            Debug.Log("完成");
            var item = ItemDatabase.instance.GetItem(completeItemID);
            ItemBox.instance.SetItem(item);
        }
    }

    public void OnFailed()
    {
        KamaHintPanel.SetActive(true);
        Debug.Log("大きな釜がある。何かを合成できるかも・・？");
    }
}
