using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameItem : MonoBehaviour
{
    public int itemID;

    // Start is called before the first frame update
    void Start()
    {
        // スクリプトでボタンクリックイベントをリンクする場合
        //var button = gameObject.GetComponent<Button>();
        //button.onClick.AddListener(OnClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClicked()
    {
        var item = ItemDatabase.instance.GetItem(this.itemID);
        ItemBox.instance.SetItem(item);

        Debug.Log(item.name + "を手に入れた！");

        Destroy(gameObject);
    }
}
