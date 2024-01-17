using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSripControll : MonoBehaviour
{
    public float slideSpeed = 6f; // 滑る速度

    private bool isSliding = false; // 滑っているかどうかのフラグ
    private bool isBlockedByStone = false; // 石にぶつかっているかどうかのフラグ
    private const string IceTag = "ice"; // 氷のタグ
    private const string StoneTag = "stone"; // 石のタグ
    private const string SlimeTag = "slime"; // スライムのタグ
    private Vector3 moveDirection;

    [SerializeField]
    private AudioSource moveSE;
    [SerializeField]
    private AudioSource collisionSE;

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

        Vector3 posi = this.transform.position;
        if (transform.position.y < -2.5)
        {
            SceneManager.LoadScene("Second");
        }
    }

    // 方向キー入力を処理する
    private void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput != 0 || verticalInput != 0)
        {
            moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;
            isSliding = true;
            moveSE.Play();
        }
    }

    // 氷の上で滑る
    private void SlideOnIce(Vector3 moveDirection)
    {
        transform.Translate(moveDirection * slideSpeed * Time.deltaTime, Space.World);
    }

    // 衝突した時の処理
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(StoneTag))
        {
            // 石にぶつかった時の処理
            HandleStoneCollision();
        }
        // else if (collision.gameObject.CompareTag(SlimeTag))
        // {
        //     // スライムにぶつかった時の処理
        //     SlideOnIce(moveDirection *= -1);
        // }
    }

    private void OnCollisionStay(Collision other)  // 衝突後に氷山側にキー入力しても防げる
    {
        if (other.gameObject.CompareTag(StoneTag))
        {
            // 石にぶつかった時の処理
            HandleStoneCollision();
        }

    }

    // 石にぶつかった時の処理
    private void HandleStoneCollision()
    {
        isSliding = false;
        collisionSE.Play();
    }
}
