using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// 걷는 속도
    /// </summary>
    public float walkSpeed = 3.0f;

    /// <summary>
    /// 뛰는 속도
    /// </summary>
    public float runSpeed = 5.0f;

    /// <summary>
    /// 현재 속도(걷거나 뛰는 것 중 하나)
    /// </summary>
    float currentSpeed = 5.0f;

    /// <summary>
    /// 이동 상태 표시용 enum
    /// </summary>
    enum MoveMode
    {
        Walk = 0,
        Run
    }

    /// <summary>
    /// 현재 이동 상태
    /// </summary>
    MoveMode moveMode = MoveMode.Run;

    /// <summary>
    /// 입력된 이동 방향
    /// </summary>
    Vector3 inputDir = Vector3.zero;

    /// <summary>
    /// 인풋 액션 인스턴스
    /// </summary>
    PlayerInputActions inputActions;

    // 컴포넌트들
    Animator animator;
    CharacterController controller;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
        inputActions.Player.MoveModeChange.performed += OnMoveModeChange;
    }

    private void OnDisable()
    {
        inputActions.Player.MoveModeChange.performed -= OnMoveModeChange;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Disable();
    }

    private void Update()
    {
        controller.Move(Time.deltaTime * currentSpeed * inputDir);  // 좀 더 수동으로 움직이는 느낌
        //controller.SimpleMove(currentSpeed * inputDir);   // 간단하게 움직이기(중력같은 것도 알아서 처리)
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        inputDir.x = input.x;
        inputDir.y = 0.0f;
        inputDir.z = input.y;

        if( !context.canceled )
        {
            // 이동 입력이 들어왔다.
            animator.SetFloat("Speed", 1.0f);
        }
        else
        {
            // 이동 입력이 끝났다.
            animator.SetFloat("Speed", 0.0f);
        }
    }

    private void OnMoveModeChange(InputAction.CallbackContext _)
    {
    }

}
