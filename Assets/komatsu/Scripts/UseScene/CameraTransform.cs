using UnityEngine;

public class CameraTransform : MonoBehaviour
{
    [SerializeField]
    public Transform penguin; // プレイヤーのTransform
    public float rotationSpeed = 3.0f;

    private float mouseX;
    private float mouseY;

    void Update()
    {
        HandleRotation();
    }

    void HandleRotation()
    {
        if (Input.GetMouseButton(0))
        {
            mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
            mouseY = Mathf.Clamp(mouseY, -35f, 60f); // 上下の回転角度を制限

            transform.LookAt(penguin);
            penguin.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
    }
}





