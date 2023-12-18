
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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

        // Y軸方向の入力を無視して、Z軸方向に進むように修正
        Vector3 velocity = new Vector3(_inputx, 0, _inputy);
        Vector3 direction = velocity.normalized;
        float distance = _speedPG * Time.deltaTime;

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
