using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float walkSpeed = 3f; // 歩く速度
    public float slideSpeed = 5f; // 滑る速度
    public Animator playerAnimator; // プレイヤーアニメーター

    private bool isSliding = false; // 滑っているかどうかのフラグ
    private bool isBlockedByStone = false; // 石にぶつかっているかどうかのフラグ
    private const float StoneBlockDuration = 1.0f; // 石にぶつかった後のブロック状態の期間
    private const string IceTag = "ice"; // 氷のタグ
    private const string StoneTag = "stone"; // 石のタグ

    void Update()
    {
        // 石にぶつかっていない場合のみ入力を受け付ける
        if (!isBlockedByStone)
        {
            // 入力を処理する
            HandleMovementInput();
            // アニメーションを更新する
            UpdateAnimator();
        }
    }

    // 入力を処理する
    private void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

            if (isSliding)
            {
                // 氷の上では滑る
                SlideOnIce(moveDirection);
            }
            else
            {
                // それ以外のタイル上では歩く
                WalkOnOtherTiles(moveDirection);
            }
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

    // アニメーターを更新する
    private void UpdateAnimator()
    {
        if (playerAnimator != null)
        {
            playerAnimator.SetBool("IsSliding", isSliding);
        }
    }

    // 衝突した時の処理
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(StoneTag))
        {
            // 石にぶつかった時の処理を実行
            HandleStoneCollision();
        }
        else if (other.gameObject.CompareTag(IceTag))
        {
            // 氷のタイルに触れたら滑る状態にする
            isSliding = true;
        }
    }

    // 石にぶつかった時の処理
    private void HandleStoneCollision()
    {
        Debug.Log("Hit stone!");
        // 石にぶつかったら止まり、再度入力を受け付ける
        StartCoroutine(BlockedByStone());
    }

    // 衝突からの待機時間後に再び入力を受け付ける
    IEnumerator BlockedByStone()
    {
        isBlockedByStone = true;
        yield return new WaitForSeconds(StoneBlockDuration);
        isBlockedByStone = false;
    }

    // タイルから離れた時の処理
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(IceTag))
        {
            // 氷のタイルから離れたら滑り状態を解除
            isSliding = false;
        }
    }
}