using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemUsableObject : MonoBehaviour
{
    public int keyItem; // 正解となるアイテム

    public bool isDestroyUsedItem;  // 使ったアイテムを処分するフラグ

    public UnityEvent onClickEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClicked()
    {
        Debug.Log("OnClicked");

        // アイテムが選択されていないときは何もしない
        var item = ItemBox.instance.GetSelectedItem();
        if(item == null) return;

        // キーアイテムとは違うアイテムが選ばれているときも何もしない
        if(item.itemID != keyItem) return;

        onClickEvent.Invoke();

        if(isDestroyUsedItem)
        {
            ItemBox.instance.RemoveItem(item);
        }
    }
}
