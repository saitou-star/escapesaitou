using UnityEngine;

public class PlayerPositionGetter : MonoBehaviour
{
    private Transform playerTransform;

    private void Start()
    {
        // タグが"Player"のオブジェクトを検索して取得
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        
        // プレイヤーオブジェクトが見つかった場合、そのTransformを保存
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player not found in the scene!");
        }
    }

    private void Update()
    {
        // プレイヤーの位置をログに出力
        if (playerTransform != null)
        {
            Debug.Log("Player Position: " + playerTransform.position);
        }
    }
}