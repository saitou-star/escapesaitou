using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureBox : MonoBehaviour
{
    bool isOpen = false;

    [SerializeField]
    Sprite openSprite;  // 開いた後の画像

    [SerializeField]
    Image img;

    [SerializeField]
    GameObject getItem;

    void Start()
    {
        getItem.SetActive(false);
    }

    // 宝箱を開ける
    public void OnOpen()
    {
        if(isOpen) return;
        isOpen = true;

        Debug.Log("OnOpen");
        
        img.sprite = openSprite;
        getItem.SetActive(true);
    }
}
