using UnityEngine;

public class NumberPanel : MonoBehaviour
{
    public int digit; // 数字を保持する変数
    // passKeyControllerの参照をInspector上で設定する
    public PassKeyController passKeyController;

    public void OnMouseDown()
    {
        // 数字がクリックされたら PassKeyController に通知
        passKeyController.OnPanelClick(digit);
    }
}
