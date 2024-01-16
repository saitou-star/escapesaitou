using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closescript : MonoBehaviour
{
    public Canvas canvas; // 対象のCanvas
    public Image end_1;     // 非表示にするImage1~6
    public Image end_2;
    public Image end_3;
    public Image end_4;
    public Image end_5;
    public Image end_6;

    void Update()
    {
        // 左クリックを検知
        if (Input.GetMouseButtonDown(0))
        {
            // クリックされたのが end_1 の場合
            if (IsMouseOverUIElement(end_1))
            {
                end_1.enabled = false;
            }
            // クリックされたのが end_2 の場合
            else if (IsMouseOverUIElement(end_2))
            {
                end_2.enabled = false;
            }
            // クリックされたのが end_3 の場合
            else if (IsMouseOverUIElement(end_3))
            {
                end_3.enabled = false;
            }
            // クリックされたのが end_4 の場合
            else if (IsMouseOverUIElement(end_4))
            {
                end_4.enabled = false;
            }
            // クリックされたのが end_5 の場合
            else if (IsMouseOverUIElement(end_5))
            {
                end_5.enabled = false;
            }
            // クリックされたのが end_6 の場合
            else if (IsMouseOverUIElement(end_6))
            {
                end_6.enabled = false;
            }
        }
    }

    // マウスがUI要素上にあるかどうかを判定するメソッド
    private bool IsMouseOverUIElement(Image uiElement)
    {
        RectTransform rectTransform = uiElement.GetComponent<RectTransform>();
        Vector2 localMousePosition = rectTransform.InverseTransformPoint(Input.mousePosition);
        return rectTransform.rect.Contains(localMousePosition);
    }
}