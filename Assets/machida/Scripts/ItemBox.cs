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

    private void Awake()
    {
        instance = this;
        itemDetailParent.gameObject.SetActive(false);
    }

    private void Update()
    {
    }



    // アイテムを入手する
    public void SetItem(Item item)
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

    public void RemoveItem(Item item)
    {
        foreach(var sl in slots)
        {
            if(sl.GetItem() == item)
            {
                sl.Clear();
                sl.Select(false);
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
}