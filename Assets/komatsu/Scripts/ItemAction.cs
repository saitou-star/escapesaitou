using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAction : MonoBehaviour
{


    public static void FireExtinguishing()
    {
        // アイテムの実行処理をここに記述
        Debug.Log("アイテムが消火されました！");
        ItemBox.instance.RemoveSelectedItem();
    }
}

