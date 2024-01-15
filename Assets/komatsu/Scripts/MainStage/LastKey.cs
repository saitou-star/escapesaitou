using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastKey : MonoBehaviour
{
    int completeNum = 0;

    [SerializeField]
    private AudioSource UseLastKeySE;
    [SerializeField]
    private GameObject LastKeyHintPanel;

    private GameObject door;

    [SerializeField]
    private int keyItemId; // キーアイテムのID

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                door = hit.collider.gameObject;

                // クリックされたオブジェクトのタグが"door"で、かつ選択されたアイテムが正しい場合に消す
                Item selectedItem = ItemBox.instance.GetSelectedItem();
                if (door.CompareTag("door") && selectedItem != null && selectedItem.itemID == keyItemId)
                {
                    OnUseItem(selectedItem); // 選択されたアイテムを引数として渡す
                }
            }
        }
    }

    public void OnUseItem(Item selected)
    {
        UseLastKeySE.Play(); // AudioSourceのPlayメソッドでSEを再生
        Debug.Log("ドアが開いた！");
        // 選択されたアイテムを削除
        ItemBox.instance.RemoveItem(selected);
        ToEnding();



    }

    public void OnFailed()
    {
        LastKeyHintPanel.SetActive(true);
        Debug.Log("鍵が必要なようだ…");
    }

    public void ToEnding()
    {
        // シーンをロードする前にDontDestroyOnLoadでマークしたオブジェクトを破棄
        ItemBox itemBoxInstance = ItemBox.instance;
        if (itemBoxInstance != null)
        {
            Destroy(itemBoxInstance.gameObject);
        }

        SceneManager.LoadScene("Ending");
    }

}

