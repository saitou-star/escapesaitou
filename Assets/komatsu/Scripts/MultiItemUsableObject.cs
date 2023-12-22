using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultiItemUsableObject : MonoBehaviour
{
    public List<int> keyItems; //正解のアイテムリスト

    public bool isDestroyUsedItem; // 使ったアイテムを処分

    public UnityEvent onClickEvent;

    public UnityEvent failedEvent;

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
        if(item == null)
        {
            failedEvent.Invoke();
            return;
        }
            

        // キーアイテムとは違うアイテムが選ばれているときも何もしない
        
        bool isMatch = false;
        for(int i = 0; i<keyItems.Count; i++)
        {
            // キーアイテムとマッチしていたらtrue
            if(item.itemID == keyItems[i])
            {
                isMatch = true;
            }
        }
        // キーアイテムとマッチしていなかったらreturnする
        if(isMatch == false)
        {
            failedEvent.Invoke();
            return;
        }
         onClickEvent.Invoke();

        if(isDestroyUsedItem)
        {
            ItemBox.instance.RemoveItem(item);
        }        
    }
}
