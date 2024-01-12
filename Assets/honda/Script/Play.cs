using System;
using System.Collections;
using System.Collections.Generic;
using MoonSharp.Interpreter;
using UnityEngine;

public class Play : MonoBehaviour//プレイヤースクリプト
{
    // public readonly float SPEED = 0.05f;
    private Rigidbody rigidBody;
    private Vector3 input;
    public float stopf = 1;
    Animator animator;
    State state;

    // public String PlayerControllerScript;



    public enum State
    {
        Normal,
        Talk,
        Command,
    }

    public void SetState()
    {
        Debug.Log("setstate");
        // this.state = state;
        stopf = 0;
        animator.enabled = true;
        rigidBody.isKinematic = true;
        // float SPEED = 0.00f;

        if (state == State.Normal)
        {
            stopf = 1;
            animator.enabled = true;
            rigidBody.isKinematic = true;
            PlayerController playerControllerScript = GetComponent<PlayerController>();
            playerControllerScript.enabled = false;
        }
        else if (state == State.Talk)
        {
            stopf = 0;
            animator.enabled = false;
        }
        else if (state == State.Command)
        {
            stopf = 0;
            animator.enabled = false;
        }
    }
    public State GetState()
    {
        return state;
    }

    void Start()
    {
        this.rigidBody = GetComponent<Rigidbody>();
        this.rigidBody.constraints = RigidbodyConstraints.FreezeRotation;
        animator = GetComponent<Animator>();
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
}