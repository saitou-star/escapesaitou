using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemBox : MonoBehaviour
{
    //アイテムボックスがすべてのスロットを取得
    [SerializeField] Slot[] slots = default;

    [SerializeField] Transform itemDetailParent;

    GameObject detail = null;

    //どこからでもアクセスできる
    public static ItemBox instance;
    public GameObject itemBoxPanel;
    private Item selectedItem;

    private void Awake()
    {
        instance = this;
        itemDetailParent.gameObject.SetActive(false);
    }

    private void Update()
    {
        // マウスの左ボタンが右クリックされたらアイテムを使用する
        if (Input.GetMouseButtonDown(1))
        {
            UseItemAction(selectedItem);
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
                selectedItem = item;
                break;
            }
        }
    }

    public void SelectItem(Slot slot)
    {
        foreach (var sl in slots)
        {
            if (sl == slot) sl.Select(true);
            else sl.Select(false);
        }
    }

    public void CreateItemDetail(Item item)
    {
        itemDetailParent.gameObject.SetActive(true);
        detail = Instantiate(item.detailPrefab, itemDetailParent);
        Debug.Log("3");
    }

    public void OnCheck()
    {
        foreach (var sl in slots)
        {
            if (sl.isSelected)
            {
                sl.OnCheckItem();
            }
        }
    }

    public Item GetSelectedItem()
    {
        foreach (var sl in slots)
        {
            if (sl.isSelected)
            {
                return sl.GetItem();
            }
        }
        return null;
    }

    public void OnCloseDetail()
    {
        if (detail != null)
        {
            Destroy(detail);
        }
        itemDetailParent.gameObject.SetActive(false);
    }

    public void RemoveSelectedItem()
    {
        if (selectedItem != null)
        {
            Destroy(detail);
            selectedItem = null;
            itemDetailParent.gameObject.SetActive(false);

            // 選択中のアイテムをスロットからも削除
            Slot selectedSlot = GetSelectedSlot();
            if (selectedSlot != null)
            {
                selectedSlot.Clear();
                selectedSlot.Select(false);
            }
        }
    }

    private Slot GetSelectedSlot()
    {
        foreach (var sl in slots)
        {
            if (sl.isSelected)
            {
                return sl;
            }
        }
        return null;
    }

    // アイテムIDごとにアクションを実行
    private void UseItemAction(Item item)
    {
        switch (item.itemID)
        {
            case 3:
                ItemAction.FireExtinguishing();
                break;
            case 2:
                // 別のアイテムIDに対する処理を追加
                break;
            // 必要に応じて追加
            default:
                break;
        }
    }
}