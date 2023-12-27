using UnityEngine;

public class ObjectClickHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject panelToShow;  // 表示するUIパネル

    private void Update()
    {
        // マウスの左クリックを検知
        if (Input.GetMouseButtonDown(0))
        {
            // クリックしたスクリーン座標をRayに変換
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Rayがオブジェクトにヒットしたら
            if (Physics.Raycast(ray, out hit))
            {
                // ヒットしたオブジェクトが指定したものであれば
                if (hit.collider.gameObject == gameObject)
                {
                    // クリックされたオブジェクトが指定したものであれば、パネルを表示
                    if (panelToShow != null)
                    {
                        panelToShow.SetActive(true);
                    }
                }
            }
        }
    }
}
