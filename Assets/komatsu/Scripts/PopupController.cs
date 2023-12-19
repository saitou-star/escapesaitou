using UnityEngine;

public class PopupController : MonoBehaviour
{
    public GameObject popupPanel; // ポップアップのパネル

    void Update()
    {
        // マウスがクリックされたらポップアップを表示
        if (Input.GetMouseButtonDown(0))
        {
            // マウスの位置を取得
            Vector3 mousePosition = Input.mousePosition;

            // Raycastでクリックした位置から対象のオブジェクトを判定
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // クリックした位置によって処理を変更することができます
                // ここではサンプルとして、ポップアップパネルをアクティブにします
                if (hit.collider.gameObject.CompareTag("PopupTrigger"))
                {
                    ShowPopup(mousePosition);
                }
            }
        }
    }

    // ポップアップを表示するメソッド
    void ShowPopup(Vector3 position)
    {
        // ポップアップパネルをクリックした位置に表示
        popupPanel.SetActive(true);
        popupPanel.transform.position = position;
    }
}

