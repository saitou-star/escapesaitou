using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;  // プレイヤーキャラクターのTransform
    private float followSpeed = 5f; // カメラの追尾速度

    [SerializeField]
    private float distance = 5f;  // カメラとキャラクターの距離
    [SerializeField]
    private float height = 2f;  // カメラの高さ

    [SerializeField]
    private Vector2 minLimit = new Vector2(-10f, -5f); // XとYの最小制限

    [SerializeField]
    private Vector2 maxLimit = new Vector2(10f, 5f);   // XとYの最大制限

    void Update()
    {
        if (target != null)
        {
            // キャラクターから一定の距離と高さを保ちつつ追尾
            Vector3 desiredPosition = target.position - target.forward * distance + Vector3.up * height;

            // カメラの位置をXとYで制約
            float clampedX = Mathf.Clamp(desiredPosition.x, minLimit.x, maxLimit.x);
            float clampedY = Mathf.Clamp(desiredPosition.y, minLimit.y, maxLimit.y);

            Vector3 targetPosition = new Vector3(clampedX, clampedY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}


