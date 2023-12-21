using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    //アイテムボックスがすべてのスロットを取得
    [SerializeField] Slot[] slots = default;
    //どこからでもアクセスできる
    public static ItemBox instance;
    public GameObject itemBoxPanel;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 二重で起動されないようにする
            Destroy(gameObject);
        }
    }
    //クリックしたらアイテムを受け取る
    public void SetItem(Item item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Slot slot = slots[i];
            if (slot.IsEmpty())
            {
                slot.Set(item);
                break;
            }
        }
    }

}