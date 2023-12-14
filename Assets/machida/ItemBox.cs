using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    void Update()
    {
        // スペースキーが押された場合
        if (Input.GetKeyDown(KeyCode.F1))
        {
            // クリック（またはスペースキー）時の処理を呼び出す
            Destroy(slots[0]);
        }
    }
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