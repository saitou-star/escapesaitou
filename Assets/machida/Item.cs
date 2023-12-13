using System;
using UnityEngine;

[Serializable]//inspectorで表示できるようにする
public class Item
{
    //アイテムの種類
    public enum Type
    {
        key,
        Cube,
        Circle,
        //アイテムを追加する場合ここに書き足す
    }
    //タイプを持たせる
    public Type type;
    //画像を持たせる
    public Sprite sprite;

    public Item(Item item) 
    {
        this.type = item.type;
    }
}