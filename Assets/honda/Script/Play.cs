using System;
using System.Collections;
using System.Collections.Generic;
using MoonSharp.Interpreter;
using UnityEngine;

public class Play : MonoBehaviour//プレイヤースクリプト
{
    // public readonly float SPEED = 0.05f;
    private Rigidbody _rigidbody;
    private Vector3 input;
    public float stopf = 1;
    private Animator _penguinAnimator;
    State state;

    // public String PlayerControllerScript;



    public enum State
    {
        Normal,
        Talk,
        Command,
    }


    public State GetState()
    {
        return state;
    }

    void Start()
    {
        this._rigidbody = GetComponent<Rigidbody>();
        this._rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        _penguinAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (stopf == 1)
        {
            // 入力を取得
            input = new Vector3(
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical"));
        }
    }

    private void FixedUpdate()
    {
        if (input == Vector3.zero)
        {
            return;
        }
        if (stopf == 1)
        {
            // 移動量を加算する
            // rigidBody.position += input * SPEED;
        }

        // void Stop()
        // {
        //     rigidBody.isKinematic = true;
        //     animator.SetBool("Run", false);
        //     animator.SetBool("Stop", true);

        // }

        // void Start1()
        // {
        //     Debug.Log("set");
        //     // this.state = state;
        //     stopf = 1;
        //     animator.enabled = false;
        //     rigidBody.isKinematic = false;
        // }
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

            Debug.Log("start");
            Transform _playerTransform = this.transform;
            _playerTransform.position += new Vector3(0, 0, -10.0f);



        }


    }
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