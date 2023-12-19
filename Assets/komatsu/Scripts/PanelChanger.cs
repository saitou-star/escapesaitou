using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 矢印をクリックしたら特定のPanel表示する
public class PanelChanger : MonoBehaviour
{

    public void Move_BedRoom()
    {
        this.transform.localPosition = new Vector2(0, -1000);
    }

    public void Move_FirePlaceRoom()
    {
        this.transform.localPosition = new Vector2(-2000, -1000);
    }

    public void Move_StartRoom()
    {
        this.transform.localPosition = new Vector2(0, 0);
    }

    public void Move_PreparationRoom()
    {
        this.transform.localPosition = new Vector2(-2000, 0);
    }
}
