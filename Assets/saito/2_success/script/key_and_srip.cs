using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_and_srip : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float slideSpeed = 5f;
    public Animator playerAnimator;

    private bool isSliding = false;
    private bool hasKey = false;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

            if (isSliding)
            {
                transform.Translate(moveDirection * slideSpeed * Time.deltaTime, Space.World);
            }
            else
            {
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

        // アイテムを使用する処理
        if (Input.GetKeyDown(KeyCode.E) && hasKey)
        {
            UseKey();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("stone"))
        {
            Debug.Log("Hit stone!");
        }
        else if (other.gameObject.CompareTag("ice"))
        {
            isSliding = true;
        }
        else if (other.gameObject.CompareTag("key"))
        {
            // アイテム（鍵）を取得
            Destroy(other.gameObject);
            hasKey = true;
            Debug.Log("Got the key!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ice"))
        {
            isSliding = false;
        }
    }

    void UseKey()
    {
        // アイテム（鍵）を使用する処理
        Debug.Log("Used the key!");
        // ここに鍵を使った際の追加の処理を書く
    }
}