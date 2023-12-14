using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObj : MonoBehaviour
{
    　　　//クリックしたら消える(取得)　　//アイテムの種類を設定する
    public Item.Type type =default;
　　//クリックした時の処理
　　//データベースからアイテムを生成
　　//クリックしたら消える
　　//アイテムボックスに入れる
    public void OnClickObj()
    {
        Item item = ItemDatabase.instance.Spawn(type);
        ItemBox.instance.SetItem(item);
        gameObject.SetActive(false);

    }
// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
