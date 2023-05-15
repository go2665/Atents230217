using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // 순찰
    // - 정해진 웨이포인트 지점을 반복해서 이동
    // - 웨이포인트 지점에 도착하면 일정 시간 정지

    // 추적
    // - 순찰 중에 플레이어 발견하면 추적
    // - 시야 범위에서 플레이어가 벗어나면 다시 순찰

    // 공격
    // - 플레이어가 공격 범위안에 들어오면 공격 시작

    // 사망
    // - 플레이어에게 일정 이상 데미지를 입으면 사망
    // - 사망하면 파티클 이팩트 재생

    protected enum EnemyState
    {
        Wait = 0,   // 대기 상태
        Patrol,     // 순찰 상태
        Chase,      // 추적 상태
        Attack,     // 공격 상태
        Die         // 죽은 상태
    }

    /// <summary>
    /// 현재 적의 상태
    /// </summary>
    EnemyState state = EnemyState.Patrol;   // Start할 때 wait로 설정하기 위해 임시로 설정

    /// <summary>
    /// 상태를 확인하고 변경시 일어나는 처리를 하는 프로퍼티
    /// </summary>
    EnemyState State
    {
        get => state;
        set
        {
            if (state != value)     // 상태가 변경될 때만 실행
            {
                state = value;
                switch (state)      // 변경된 상태에 따라 서로 다른 처리를 수행
                { 
                    case EnemyState.Wait:
                        // Wait 상태가 될 때 처리해야 할 일들
                        agent.isStopped = true;         // 길찾기로 움직이던 것 정지
                        agent.velocity = Vector3.zero;  // 길찾기 관성 제거
                        anim.SetTrigger("Stop");        // Idle 애니메이션 재생
                        WaitTimer = waitDuration + UnityEngine.Random.Range(0.0f, 0.5f);    // 기다릴 시간 설정
                        stateUpdate = Update_Wait;      // Wait 상태용 업데이트 함수 설정
                        break;
                    case EnemyState.Patrol:
                        // Patrol 상태가 될 때 처리해야 할 일들
                        agent.isStopped = false;        // 길찾기 정지를 해제(다시 움직일 수 있게 설정)
                        agent.SetDestination(moveTarget.position);  // 움직일 목적지 설정
                        anim.SetTrigger("Move");        // 이동 애니메이션 재생
                        stateUpdate = Update_Patrol;    // Patrol 상태용 업데이트 함수 설정
                        break;
                    case EnemyState.Chase:
                        // Chase 상태가 될 때 처리해야 할 일들
                        agent.isStopped = false;        // 길찾기 정지를 해제(다시 움직일 수 있게 설정)
                        agent.SetDestination(chaseTarget.position); // 추적 대상으로 이동하게 설정
                        anim.SetTrigger("Move");        // 이동 애니메이션 재생
                        stateUpdate = Update_Chase;     // Chase 상태용 업데이트 함수 설정
                        break;
                    case EnemyState.Attack:
                        break;
                    case EnemyState.Die:
                        break;
                }
            }
        }
    }

    /// <summary>
    /// 상태별 Update함수를 저장할 델리게이트
    /// </summary>
    Action stateUpdate = null;

    // 순찰 관련 데이터 ----------------------------------------------------------------------------
    
    /// <summary>
    /// 순찰할 웨이포인트 모음
    /// </summary>
    public Waypoints waypoints;

    /// <summary>
    /// 지금 이동할 목적지
    /// </summary>
    Transform moveTarget;

    // 대기 관련 데이터 ----------------------------------------------------------------------------
    
    /// <summary>
    /// 목적지에 도달하면 기다리는 시간
    /// </summary>
    public float waitDuration = 1.0f;

    /// <summary>
    /// 실제로 기다릴 시간
    /// </summary>
    float waitTimer = 0.0f;
    float WaitTimer
    {
        get => waitTimer;
        set
        {
            waitTimer = value;
            if( waypoints != null && waitTimer < 0.0f)  // waitTimer이 0보다 작아지면 순찰 상태로 전환
            {
                State = EnemyState.Patrol;
            }
        }
    }

    // 추적 관련 데이터 ----------------------------------------------------------------------------
    
    /// <summary>
    /// 전체 시야 범위
    /// </summary>
    public float sightRange = 10.0f;

    /// <summary>
    /// 시야각의 절반
    /// </summary>
    public float sightHalfAngle = 50.0f;

    /// <summary>
    /// 근접 시야 범위
    /// </summary>
    public float closeSightRange = 2.5f;

    /// <summary>
    /// 추적할 대상의 트랜스폼
    /// </summary>
    Transform chaseTarget;

    // 컴포넌트 ------------------------------------------------------------------------------------

    NavMeshAgent agent;
    Animator anim;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        Waypoints defaultWaypoints = GetComponentInChildren<Waypoints>();
        defaultWaypoints.transform.SetParent(null);
        if ( waypoints == null ) 
        {
            waypoints = defaultWaypoints;   // 따로 설정한 웨이포인트가 없으면 자식으로 붙어있는 웨이포인트 사용
        }
    }

    private void Start()
    {
        moveTarget = waypoints.Current;
        State = EnemyState.Wait;
        anim.ResetTrigger("Stop");          // 첫 Wait 상태로 가면서 Stop 트리거가 미리 설정되는 것 방지
    }

    private void Update()
    {
        stateUpdate();      // 현재 상태의 Update 함수 수행
    }

    /// <summary>
    /// 순찰용 Update 함수
    /// </summary>
    void Update_Patrol()
    {
        if (SearchPlayer())
        {
            // 플레이어 발견하면 즉시 추적상태로 변경
            State = EnemyState.Chase;
        }
        else if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            // 목적지에 도착했다.
            moveTarget = waypoints.Next();  // 도착하면 다음 지점 설정해 놓고
            State = EnemyState.Wait;        // 대기 상태로 변경
        }
    }

    /// <summary>
    /// 대기용 Update 함수
    /// </summary>
    void Update_Wait()
    {
        if (SearchPlayer())
        {
            // 플레이어 발견하면 즉시 추적상태로 변경
            State = EnemyState.Chase;
        }
        else
        {
            // 그냥 기다리고 있는 상황이면
            WaitTimer -= Time.deltaTime;    // 타이머만 계속 감소
        }
    }

    void Update_Chase()
    {
        if (SearchPlayer())
        {
            // 플레이어 발견하면 즉시 추적상태로 변경
            State = EnemyState.Chase;
        }
        else
        {
            // 안보이면 대기 상태로
            State = EnemyState.Wait;
        }
    }

    bool SearchPlayer()
    {
        bool result = false;

        Collider[] colliders = Physics.OverlapSphere(transform.position, sightRange, LayerMask.GetMask("Player"));
        if(colliders.Length > 0 )
        {
            Vector3 playerPos = colliders[0].transform.position;
            Vector3 toPlayerDir = playerPos - transform.position;
            if(toPlayerDir.sqrMagnitude < closeSightRange * closeSightRange)
            {
                // 근접 시야 범위 안에 플레이어가 있다.
                chaseTarget = colliders[0].transform;
                result = true;
            }
            else
            {
                // 전체 시야 범위 안에 플레이어가 있다.
                float angle = Vector3.Angle(transform.forward, toPlayerDir);
                if(angle < sightHalfAngle)
                {
                    // 시야각 안에 플레이어가 있다.
                    Ray ray = new Ray(transform.position + transform.up * 0.5f, toPlayerDir);
                    if( Physics.Raycast(ray, out RaycastHit hit, sightRange))
                    {
                        // 시야에 부딪친 물체가 있다.
                        if( hit.collider.CompareTag("Player"))
                        {
                            // 부딪친 물체가 플레이어이다.
                            chaseTarget = colliders[0].transform;
                            result = true;
                        }
                    }
                }
            }
        }

        return result;
    }
}
