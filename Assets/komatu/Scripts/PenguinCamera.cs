using UnityEngine;

public class PenguinCamera : MonoBehaviour
{
    [SerializeField]
    private Transform penguin; // プレイヤーのTransform
    private float followSpeed = 5f; // カメラの追尾速度

    [SerializeField]
    private Vector2 minLimit = new Vector2(-10f, -5f); // XとYの最小制限

    [SerializeField]
    private Vector2 maxLimit = new Vector2(10f, 5f);   // XとYの最大制限

    void Update()
    {
        if (penguin != null)
        {
            // プレイヤーの位置を追尾
            float clampedX = Mathf.Clamp(penguin.position.x, minLimit.x, maxLimit.x);
            float clampedY = Mathf.Clamp(penguin.position.y, minLimit.y, maxLimit.y);

            Vector3 targetPosition = new Vector3(clampedX, clampedY, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}

