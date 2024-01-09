using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueShowPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject Panel;  // 衝突時に表示するUIパネル

    private void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトがプレイヤーに設定したタグを持っているか確認
        if (collision.gameObject.CompareTag("Player"))
        {
            // 衝突時にUIパネルを表示
            if (Panel != null)
            {
                Panel.SetActive(true);
            }
        }
    }
}
