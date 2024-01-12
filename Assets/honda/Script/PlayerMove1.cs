using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

public class PlayerMove1 : MonoBehaviour
{
    [SerializeField]
    private float _speedPG = 10.0f;
    private float _inputx;
    private float _inputy;
    private Transform _playerTransform;
    private Animator _penguinAnimator;
    private Rigidbody _rigidbody;
    private AudioSource playerAudioSource;



    // private Vector3 input;
    public float stopf = 1;
    State state;

    public enum State
    {
        Normal,
        Talk,
        Command,
    }

    void Start()
    {
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
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
    public void SetState()
    {

        // this.state = state;
        // stopf = 1;
        // _penguinAnimator.enabled = true;
        // _rigidbody.isKinematic = true;
        // float SPEED = 0.00f;

        if (state == State.Normal)
        {
            Debug.Log("setstate");
            stopf = 1;
            _penguinAnimator.enabled = false;
            _rigidbody.isKinematic = true;
            // PlayerController playerControllerScript = GetComponent<PlayerController>();
            // playerControllerScript.enabled = false;
        }
        else if (state == State.Talk)
        {
            stopf = 0;
            _penguinAnimator.enabled = false;
        }
        else if (state == State.Command)
        {
            stopf = 0;
            _penguinAnimator.enabled = true;
            _rigidbody.isKinematic = false;
            Update();
            // UpdateAnimator();
            // TurnPlayer();
            Start();
            _speedPG = 10.0f;
            Debug.Log("start");
            Transform _playerTransform = this.transform;
            _playerTransform.position += new Vector3(0, 0, -10.0f);



        }


    }
    // public State GetState()
    // {
    //     return state;
    // }

    public void No()
    {
        state = State.Normal;
        return;

    }
    public void Yes()
    {
        state = State.Command;
        return;
    }
}
