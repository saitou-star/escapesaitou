using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 矢印をクリックしたら特定のPanel表示する
public class PanelChanger : MonoBehaviour
{
    String currentPanel = "Panel0";
    public void OnRightArrow()
    {
        // Panel1を表示したい
        this.transform.localPosition = new Vector2(-2000,-1000);
        currentPanel = "Panel1";
    }

    public void OnLeftArrow()
    {
        this.transform.localPosition = new Vector2(0,-1000);
    }

    public void OnUpArrow()
    {
        this.transform.localPosition = new Vector2(0,-1000);
    }

    public void OnBackArrow()
    {
         this.transform.localPosition = new Vector2(-2000,-1000);
    }
}
