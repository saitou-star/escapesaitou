using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{

    //アイテムボックスがすべてのスロットを取得
    [SerializeField] Slot[] slots= default;

    //どこからでもアクセスできる
    public static ItemBox instance;
    private void Awake()
    {
        instance = this;
    }
    //クリックしたらアイテムを受け取る
    public void SetItem(Item item)
    {
        for(int i =0; i<slots.Length; i++) 
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