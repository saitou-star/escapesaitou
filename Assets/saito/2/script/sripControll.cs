using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SripControll : MonoBehaviour
{
    public float walkSpeed = 3f; // 歩く速度
    public float slideSpeed = 6f; // 滑る速度

    private bool isSliding = false; // 滑っているかどうかのフラグ
    private bool isBlockedByStone = false; // 石にぶつかっているかどうかのフラグ
    private const float StoneBlockDuration = 0.5f; // 石にぶつかった後のブロック状態の期間
    private const string IceTag = "ice"; // 氷のタグ
    private const string StoneTag = "stone"; // 石のタグ

    private Vector3 moveDirection;

    void Update()
    {
        // 石にぶつかっていない場合のみ入力を受け付ける
        if (!isBlockedByStone)
        {
            if (isSliding != true)
            {
                HandleMovementInput();
            }
        }
        if (isSliding)
        {
            // 氷の上では滑る
            SlideOnIce(moveDirection);
        }
        Debug.Log("Sliding state: " + isSliding);
    }

    // 入力を処理する
    private void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
            isSliding = true;

        }
    }

    // 氷の上で滑る
    private void SlideOnIce(Vector3 moveDirection)
    {
        transform.Translate(moveDirection * slideSpeed * Time.deltaTime, Space.World);
    }

    // それ以外のタイル上で歩く
    private void WalkOnOtherTiles(Vector3 moveDirection)
    {
        transform.Translate(moveDirection * walkSpeed * Time.deltaTime, Space.World);
    }

    // 衝突した時の処理
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(StoneTag))
        {
            Debug.Log("Sliding statestone: " + isSliding);
            // 石にぶつかった時の処理を実行
            HandleStoneCollision();
        }
        else if (collision.gameObject.CompareTag(IceTag))
        {
            // 氷のタイルに触れたら滑る状態にする
            // isSliding = true;

            // Debug ログを追加
            Debug.Log("Sliding state: " + isSliding);
        }
    }

    // 石にぶつかった時の処理
    private void HandleStoneCollision()
    {
        isSliding = false;
        // 石にぶつかったら止まり、再度入力を受け付ける
        // StartCoroutine(BlockedByStone());
    }

    // 衝突からの待機時間後に再び入力を受け付ける
    // IEnumerator BlockedByStone()
    // {
    //     isBlockedByStone = true;
    //     yield return new WaitForSeconds(StoneBlockDuration);
    //     isBlockedByStone = false;
    //     isSliding = false;
    // }

}