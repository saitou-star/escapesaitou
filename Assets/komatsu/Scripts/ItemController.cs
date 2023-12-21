using UnityEngine;

public class ItemController : MonoBehaviour
{
    private void Update()
    {
        // マウスクリックまたはスペースキーが押されたら
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            // Raycast で画面上のポイントをクリックした位置に対して物理的なオブジェクトが存在するかをチェック
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // 当たったオブジェクトがアイテムであれば
                if (hit.collider.CompareTag("Item"))
                {
                    // アイテムをアイテムボックスにセット
                    Item item = hit.collider.GetComponent<Item>();
                    if (item != null)
                    {
                        PlayerItemBox.instance.SetItem(item);
                        // アイテムを削除（オプション）
                        Destroy(item.gameObject);
                    }
                }
            }
        }
    }
}
