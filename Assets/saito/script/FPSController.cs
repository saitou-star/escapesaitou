using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    float x, z;
    float speed = 0.1f;

    public GameObject cam;
    Quaternion cameraRot, characterRot;
    float Xsensityvity = 3f, Ysensityvity = 3f;

    // 下、canvasの表示非表示(canvasは変数名で何でもよい、このスクリプトをアタッチしたものが表示が変わる)
    // public GameObject canvas;   どっかに書く = canvas.SetActive(true)

    bool cursorLock = true;

    //変数の宣言(角度の制限用)
    float minX = -90f, maxX = 90f;

    // Start is called before the first frame update
    void Start()
    {

        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        // 左クリックが押されている場合にのみ視点を変更
        if (Input.GetMouseButton(0))
        {
            float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
            float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

            cameraRot *= Quaternion.Euler(-yRot, 0, 0);
            characterRot *= Quaternion.Euler(0, xRot, 0);

            // Updateの中で作成した関数を呼ぶ
            cameraRot = ClampRotation(cameraRot);

            cam.transform.localRotation = cameraRot;
            transform.localRotation = characterRot;
        }

        UpdateCursorLock();
    }

    private void FixedUpdate()
    {
        x = 0;
        z = 0;

        x = Input.GetAxisRaw("Horizontal") * speed;
        z = Input.GetAxisRaw("Vertical") * speed;

        // transform.position += new Vector3(x,0,z);

        transform.position += cam.transform.forward * z + cam.transform.right * x;
    }


    public void UpdateCursorLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        else if (Input.GetMouseButtonDown(0))  // 左クリックでカーソルロック
        {
            cursorLock = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            cursorLock = false;
        }


        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //角度制限関数の作成
    public Quaternion ClampRotation(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX, minX, maxX);

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }
}