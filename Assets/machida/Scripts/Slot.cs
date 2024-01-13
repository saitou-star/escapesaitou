using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image = default;
    [SerializeField] GameObject selected;
    Item item = null;

    public bool isSelected = false;

    void Start()
    {
        Select(false);
    }

    public void Set(Item item)
    {
        this.item = item;
        image.sprite = item.sprite;
    }

    public bool IsEmpty()
    {
        if (item == null)
        {
            return true;
        }
        return false;
    }

    public void OnClicked()
    {
        if (item == null) return;
        ItemBox.instance.SelectItem(this);
    }

    public void Select(bool flag)
    {
        isSelected = flag;
        // Debug.Log(this.name + ": flag->" + flag);
        selected.SetActive(flag);
    }

    public void OnCheckItem()
    {
        if (item == null) return;
        if (item.detailPrefab == null) return;
        ItemBox.instance.CreateItemDetail(item);
    }

    public Item GetItem()
    {
        return item;
    }

    public void Clear()
    {
        item = null;
        image.sprite = null;
    }
}