using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    public Item GetItem(int id)
    {
        return itemDatabaseEntity.items
            .Where(it=>it.itemID == id) // DB上のitems配列からitemIDとidが合致するものを抽出
            .FirstOrDefault();          // その中から最初の1つを返す

        // foreachを使う場合
        /*
        foreach(var it in itemDatabaseEntity.items)
        {
            if(it.itemID == id) return it;
        }
        return null;
        */
    }
}