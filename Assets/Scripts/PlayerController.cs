using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 移動速度(仮)
    private float _speed = 10.0f;
    // x軸方向の入力を保存
    private float _input_x;
    // z軸方向の入力を保存
    private float _input_z;
    // プレイヤーのTransformコンポーネント
    private Transform _playerTransform;
    private Animator _penguinAnimator;

    void Start()
    {
        _playerTransform = GetComponent<Transform>();
        _penguinAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // x軸方向、z軸方向の入力を取得
        // Horizontal（水平、横方向）
        _input_x = Input.GetAxis("Horizontal");
        // Vertical（垂直、縦方向
        _input_z = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(_input_x, 0, _input_z);
        // ベクトルの向きを取得
        Vector3 direction = velocity.normalized;
        // 移動距離を計算
        float distance = _speed * Time.deltaTime;
        // 移動先を計算
        Vector3 destination = transform.position + direction * distance;
        // プレイヤーの位置だけを更新し、向きは変更しない
        transform.position = destination;

        TurnPlayer();
        UpdateAnimator();
    }

    // 左右の向きの調整
    void TurnPlayer()
    {
        if (_input_x > 0)
        {
            _playerTransform.localScale = new Vector3(-1, 1, 1);
        }
        else if (_input_x < 0)
        {
            _playerTransform.localScale = new Vector3(1, 1, 1);
        }
    }

    void UpdateAnimator()
    {
        float moveSpeed = Mathf.Abs(_input_x) + Mathf.Abs(_input_z);

        // キーボードが押されているかどうかを確認
        bool isWalking = moveSpeed > 0;

        // アニメーションの制御
        _penguinAnimator.SetBool("Idle", !isWalking);
        _penguinAnimator.SetBool("Walk_Side", false);
        _penguinAnimator.SetBool("Walk_Front", false);
        _penguinAnimator.SetBool("Walk_Back", false);

        if (isWalking)
        {
            if (_input_x < 0)
            {
                // 左に移動
                _penguinAnimator.SetBool("Walk_Side", true);
            }
            else if (_input_x > 0)
            {
                // 右に移動
                _penguinAnimator.SetBool("Walk_Side", true);
            }
            else if (_input_z < 0)
            {
                // 後ろに移動
                _penguinAnimator.SetBool("Walk_Front", true);
            }
            else if (_input_z > 0)
            {
                // 前に移動
                _penguinAnimator.SetBool("Walk_Back", true);
            }
        }
    }
}