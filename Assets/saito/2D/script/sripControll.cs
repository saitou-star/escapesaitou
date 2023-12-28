using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sripControll : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float slideSpeed = 5f;
    public Animator playerAnimator;

    private bool isSliding = false;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

            if (isSliding)
            {
                // "ice"タイル上では滑る
                transform.Translate(moveDirection * slideSpeed * Time.deltaTime, Space.World);
            }
            else
            {
                // それ以外のタイル上では歩く
                transform.Translate(moveDirection * walkSpeed * Time.deltaTime, Space.World);
            }

            if (playerAnimator != null)
            {
                playerAnimator.SetBool("IsSliding", isSliding);
            }
        }
        else
        {
            if (playerAnimator != null)
            {
                playerAnimator.SetBool("IsSliding", false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("stone"))
        {
            Debug.Log("Hit stone!");
            // ここに石にぶつかった時の処理を追加
        }
        else if (other.gameObject.CompareTag("ice"))
        {
            // "ice"タイルに触れたら滑る状態にする
            isSliding = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ice"))
        {
            // "ice"タイルから離れたら滑り状態を解除
            isSliding = false;
        }
    }
}
