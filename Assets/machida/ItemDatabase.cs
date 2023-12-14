using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    //どこからでもアクセスできるようにする
    public static ItemDatabase instance;

    public void Awake()
    {
        instance = this;
    }

    [SerializeField] ItemDatabaseEntity itemDatabaseEntity = default;
    //itemを生成
    public Item Spawn(Item.Type type)
    {
        for (int i = 0; i < itemDatabaseEntity.items.Count; i++)
        {
            Item itemData = itemDatabaseEntity.items[i];
            //データベースから一致するものを探す
            if (itemData.type == type)
            {
                return new Item(itemData);
                //一致したら生成して渡す
            }
        }
        return null;
    }
}