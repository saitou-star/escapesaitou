using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public static ItemBox instance;
    private void Awake()
    {
        instance = this;
    }
    //クリックしたらアイテムを受け取る
    public void SetItem(Item item)
    {
        Debug.Log(item.type);
    }
}