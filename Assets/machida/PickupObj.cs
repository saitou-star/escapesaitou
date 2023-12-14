using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObj : MonoBehaviour
{
    //アイテムの種類を設定する
    public Item.Type type =default;
    
　　//データベースからアイテムを生成
　　//クリックしたら消える
　　//アイテムボックスに入れる
    public void OnClickObj()
    {
        Item item = ItemDatabase.instance.Spawn(type);
        ItemBox.instance.SetItem(item);
        gameObject.SetActive(false);

    }
}