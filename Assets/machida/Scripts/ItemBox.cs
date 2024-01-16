using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class ItemBox : MonoBehaviour
{
    //アイテムボックスがすべてのスロットを取得
    [SerializeField] Slot[] slots = default;

    [SerializeField] Transform itemDetailParent;

    GameObject detail = null;

    //どこからでもアクセスできる
    public static ItemBox instance;
    public GameObject itemBoxPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            itemDetailParent.gameObject.SetActive(false);
        }
        else
        {
            // 二重で起動されないようにする
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // セーブデータからアイテムボックスの項目を再構築
        foreach(var item in GameSaveData.Instance.saveData.ItemBox)
        {
            SetItem(ItemDatabase.instance.GetItem(item), false);
        }
    }

    // アイテムを入手する
    public void SetItem(Item item, bool isApplySaveData = true)
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

        // セーブデータに反映
        if(isApplySaveData)
        {
            ApplySaveData();
        }
    }

    void ApplySaveData()
    {
            GameSaveData.Instance.saveData.ItemBox.Clear();     // 一度削除
            for(int i = 0; i < slots.Length; i++)
            {
                if(slots[i].GetItem() == null) continue;
                GameSaveData.Instance.saveData.ItemBox.Add(slots[i].GetItem().itemID);
            }
    }
    void Update()
    {

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
       if (item == null || item.detailPrefab == null)
        {
        return;
    }

    if (itemDetailParent != null)
    {
        if (!itemDetailParent.gameObject.activeSelf)
        {
            itemDetailParent.gameObject.SetActive(true);
        }

        // もし detail が既に存在している場合は破棄
        if (detail != null)
        {
            Destroy(detail);
        }

        // 新しい詳細情報をインスタンス化
        detail = Instantiate(item.detailPrefab, itemDetailParent);
        Debug.Log("3");
    }
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

    public void RemoveItem(Item item)
    {
        foreach (var sl in slots)
        {
            if (sl.GetItem() == item)
            {
                sl.Clear();
                sl.Select(false);
            }
        }
        ApplySaveData();
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
}