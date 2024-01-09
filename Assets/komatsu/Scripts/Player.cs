using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speedPG = 10.0f;
    private float _inputx;
    private float _inputy;
    private Transform _playerTransform;
    private Animator _penguinAnimator;
    private Rigidbody _rigidbody;
    private AudioSource playerAudioSource;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerTransform = GetComponent<Transform>();
        _penguinAnimator = GetComponent<Animator>();
        playerAudioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        _inputx = Input.GetAxis("Horizontal");
        _inputy = Input.GetAxis("Vertical");

        // カメラの方向を取得して、それを基に移動方向を計算
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        Vector3 direction = (_inputx * cameraRight + _inputy * cameraForward).normalized;

        // Rigidbodyに速度情報を伝えて移動
        _rigidbody.velocity = new Vector3(direction.x * _speedPG, _rigidbody.velocity.y, direction.z * _speedPG);

        TurnPlayer();
        UpdateAnimator();
    }

    void TurnPlayer()
    {
        if (_inputx > 0)
        {
            _playerTransform.localScale = new Vector3(-1, 1, 1);
        }
        else if (_inputx < 0)
        {
            _playerTransform.localScale = new Vector3(1, 1, 1);
        }
    }

    void UpdateAnimator()
    {
        float moveSpeed = Mathf.Abs(_inputx) + Mathf.Abs(_inputy);
        bool isWalking = moveSpeed > 0;

        _penguinAnimator.SetBool("Idle", !isWalking);
        _penguinAnimator.SetBool("Walk_Side", false);
        _penguinAnimator.SetBool("Walk_Front", false);
        _penguinAnimator.SetBool("Walk_Back", false);

        if (isWalking)
        {
            if (_inputx < 0)
            {
                _penguinAnimator.SetBool("Walk_Side", true);
            }
            else if (_inputx > 0)
            {
                _penguinAnimator.SetBool("Walk_Side", true);
            }
            else if (_inputy < 0)
            {
                _penguinAnimator.SetBool("Walk_Front", true);
            }
            else if (_inputy > 0)
            {
                _penguinAnimator.SetBool("Walk_Back", true);
            }
        }
    }
}
