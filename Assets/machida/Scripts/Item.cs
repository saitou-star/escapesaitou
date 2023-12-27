using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]//inspectorで表示できるようにする
public class Item
{
    //アイテムの種類
    public enum Type
    {
        NotUseItem,
        Cube,
        Circle,
        InformationItem,
        UseItem,
        //アイテムを追加する場合ここに書き足す
    }
    public int itemID;
    public string name;
    public GameObject detailPrefab;
    public Type type;
    public Sprite sprite;

    public Item(Item item)
    {
        this.type = item.type;
        this.sprite = item.sprite;
    }

}