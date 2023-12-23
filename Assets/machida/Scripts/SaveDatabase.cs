using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Database",menuName = "自作データ/Database")]
public class SaveDatabase : ScriptableObject
{
    public List<ItemData> itemDatabase;

    // public int GetItemID(ItemData data)
    // {
    //     int index = itemDatabase.IndexOf(data);

    //     if (index == -1)
    //     {
    //         Debug.LogError("そんなアイテムはデータベース上に無いです！！！！！！！！！！！！");
    //     }
        
    //     return index;
    // }

}
