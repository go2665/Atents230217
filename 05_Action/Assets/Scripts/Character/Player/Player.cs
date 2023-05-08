using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Player : MonoBehaviour, IHealth
{
    /// <summary>
    /// 이 플레이어가 가지고 있을 인벤토리
    /// </summary>
    Inventory inven;

    /// <summary>
    /// 플레이어가 가지고 있는 돈
    /// </summary>
    int money = 0;
    public int Money
    {
        get => money;
        set
        {
            if(money != value)
            {
                money = value;
                //Debug.Log($"Money : {money}");
                onMoneyChange?.Invoke(money);
            }
        }
    }

    /// <summary>
    /// 생존 여부 표시용 변수
    /// </summary>
    bool isAlive = true;
    public bool IsAlive => isAlive;

    /// <summary>
    /// 플레이어의 현재 HP
    /// </summary>
    float hp = 100.0f;
    public float HP 
    { 
        get => hp; 
        set
        {
            hp = value;
            if( hp < 0 )
            {
                Die();
            }            
            hp = Mathf.Clamp(hp, 0, maxHP);
            onHealthChange?.Invoke(hp / maxHP);
        }
    }

    /// <summary>
    /// HP가 변경되었을 때 실행될 델리게이트
    /// </summary>
    public Action<float> onHealthChange { get; set; }

    /// <summary>
    /// 플레이어가 죽었을 때 실행될 델리게이트
    /// </summary>
    public Action onDie { get; set; }

    /// <summary>
    /// 플레이어의 최대 HP
    /// </summary>
    float maxHP = 100.0f;
    public float MaxHP => maxHP;

    /// <summary>
    /// 돈이 변경되었을 때 실행될 델리게이트
    /// </summary>
    public Action<int> onMoneyChange;

    /// <summary>
    /// 아이템을 줏을 수 있는 거리
    /// </summary>
    public float ItemPickupRange = 2.0f;

    PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerController.onItemPickUp = OnItemPickUp;   // 아이템 줍는다는 신호가 들어오면 줍는 처리 실행
    }

    private void Start()
    {
        inven = new Inventory(this);    // SceneLoaded보다 나중에 실행되어야 해서 Awake에서 하면 안됨
        GameManager.Inst.InvenUI.InitializeInventory(inven);
    }

    /// <summary>
    /// 아이템 줍는 처리를 하는 함수
    /// </summary>
    private void OnItemPickUp()
    {
        // 일정 범위 안에 있는 아이템 찾고
        Collider[] items = Physics.OverlapSphere(transform.position, ItemPickupRange, LayerMask.GetMask("Item"));
        foreach (Collider itemCollider in items)
        {
            Item item = itemCollider.gameObject.GetComponent<Item>();

            IConsumable consumable = item.ItemData as IConsumable;  // 즉시 소비되는 아이템인지 확인
            if(consumable != null)
            {
                consumable.Consume(gameObject);     // 즉시 소비되는 아이템이면 바로 사용
                Destroy(item.gameObject);           // 사용 후 제거
            }
            else if ( inven.AddItem(item.ItemData.code) ) // 하나씩 인벤토리에 추가하고
            {
                Destroy(item.gameObject);           // 성공하면 먹은 아이템 삭제하기
            }
        }
    }

    /// <summary>
    /// 플레이어 사망 처리용 함수
    /// </summary>
    public void Die()
    {
        if (IsAlive)    // 살아있을 때만 죽게 만들기
        {
            isAlive = false;
            onDie?.Invoke();
            Debug.Log("플레이어 사망");
        }
    }

    /// <summary>
    /// 테스트용
    /// </summary>
    /// <param name="code">추가할 아이템 종류</param>
    /// <param name="count">추가할 갯수</param>
    public void Test_AddItem(ItemCode code, uint count = 1)
    {
        for(int i = 0; i < count; i++)
        {
            inven.AddItem(code);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.blue;

        // 아이템 획득 반경 그리기
        Handles.DrawWireDisc(transform.position, Vector3.up, ItemPickupRange);        
    }
#endif
}
