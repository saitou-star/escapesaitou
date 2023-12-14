using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
　　//どこからでもアクセスできるようにする変数
    public static ItemBox instance;
    private void Awake()
    {
        instance = this;
    }
    //クリックしたらアイテムを受け取る
    public void SetItem(Item item)
    {
        Debug.Log(item.type);
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
