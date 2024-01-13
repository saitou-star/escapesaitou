using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour
{
    public AudioSource GetItemSound; // アイテム取得時のSE
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
        PlayGetItemSound();

        Destroy(gameObject);
    }

    private void PlayGetItemSound()
    {
        // AudioSourceコンポーネントがアタッチされているか確認
        if (GetItemSound == null)
        {
            Debug.LogError("AudioSourceがアタッチされていません。");
            return;
        }

        // SE再生
        GetItemSound.Play();
    }
}
