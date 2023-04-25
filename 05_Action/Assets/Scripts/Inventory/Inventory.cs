using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    // 필요 상수 -----------------------------------------------------------------------------------

    /// <summary>
    /// 기본 인벤토리 크기
    /// </summary>
    public const int Default_Inventory_Size = 6;

    /// <summary>
    /// 임시 슬롯의 인덱스
    /// </summary>
    public const uint TempSlotIndex = 99999999;

    // 변수 ---------------------------------------------------------------------------------------

    /// <summary>
    /// 이 인벤토리에 들어있는 슬롯의 배열
    /// </summary>
    ItemSlot[] slots;

    /// <summary>
    /// 인벤토리 슬롯에 접근하기 위한 인덱서
    /// </summary>
    /// <param name="index">접근할 슬롯의 인덱스</param>
    /// <returns>접근할 슬롯</returns>
    public ItemSlot this[uint index] => slots[index];

    /// <summary>
    /// 인벤토리 슬롯의 갯수
    /// </summary>
    public int SlotCount => slots.Length;

    /// <summary>
    /// 임시 슬롯(드래그나 분리할 때 사용)
    /// </summary>
    ItemSlot tempSlot;
    public ItemSlot TempSlot => tempSlot;

    /// <summary>
    /// 게임 메니저가 가지고 있는 아이템 데이터 메니저(모든 아이템의 데이터를 가지고 있다.(종류별))
    /// </summary>
    ItemDataManager dataManager;

    /// <summary>
    /// 생성자
    /// </summary>
    /// <param name="size">새로 만들 인벤토리의 크기</param>
    public Inventory(uint size = Default_Inventory_Size)
    {
        Debug.Log($"{size}칸짜리 인벤토리 생성");
        slots = new ItemSlot[size];             // 슬롯용 배열 만들기
        for(uint i=0;i<size; i++)
        {
            slots[i] = new ItemSlot(i);         // 슬롯 하나씩 생성
        }
        tempSlot = new ItemSlot(TempSlotIndex); // 임시 슬롯 만들고

        dataManager = GameManager.Inst.ItemData;// 데이터 메니저 캐싱해놓기
    }

    //인벤토리에 아이템 추가하기, 특정 슬롯에 추가하기

    /// <summary>
    /// 아이템을 1개 추가하는 함수
    /// </summary>
    /// <param name="data">추가될 아이템의 데이터</param>
    /// <returns>성공여부(true면 추가, false 추가실패)</returns>
    public bool AddItem(ItemData data)
    {
        bool result = false;

        // 같은 종류의 아이템이 있는지
        ItemSlot sameDataSlot = FindSameItem(data);
        if(sameDataSlot != null)
        {
            // 같은 종류의 아이템이 있으면 증가 시도
            result = sameDataSlot.IncreaseSlotItem(out uint _); // 넘치는 갯수는 의미없음. 결과만 사용
        }
        else
        {
            // 같은 종류의 아이템이 없으면 빈슬롯 찾기
            ItemSlot emptySlot = FindEmptySlot();
            if (emptySlot != null)
            {
                // 빈슬롯 찾았다.
                emptySlot.AssignSlotItem(data);
                result = true;
            }
            else
            {
                // 비어있는 슬롯이 없다.
                Debug.Log("실패 : 인벤토리가 가득 찼습니다.");
            }
        }
        return result;
    }

    public bool AddItem(ItemCode code)
    {
        return AddItem(dataManager[code]);
    }

    //인벤토리 특정 슬롯에서 일정 갯수만큼 아이템 제거하기
    void RemoveItem()
    {

    }

    /// <summary>
    /// 특정 슬롯에서 아이템을 완전히 제거하는 함수
    /// </summary>
    void ClearSlot()
    {

    }

    //인벤토리를 전부 비우기
    void ClearInventory()
    {

    }

    //아이템 이동 시키기 
    void MoveItem()
    {

    }

    //아이템 정렬
    void SlotSorting()
    {

    }

    /// <summary>
    /// 비어있는 슬롯을 찾아주는 함수
    /// </summary>
    /// <returns>null이면 비어있는 함수가 없다. null이 아니면 찾았다.</returns>
    private ItemSlot FindEmptySlot()
    {
        ItemSlot result = null;
        foreach(ItemSlot slot in slots) // 그냥 다 뒤져보기
        {
            if(slot.IsEmpty)
            {
                result = slot;
                break;
            }
        }
        return result;
    }

    /// <summary>
    /// 인벤토리에 같은 종류의 아이템이 있는지 찾아주는 함수(최대갯수인 슬롯은 제외)
    /// </summary>
    /// <param name="data">찾을 아이템</param>
    /// <returns>같은 종류의 아이템이 들어있는 슬롯(null이 아니면 찾았다. null이면 없다.)</returns>
    private ItemSlot FindSameItem(ItemData data)
    {
        ItemSlot findSlot = null;
        foreach (ItemSlot slot in slots)    // 전부 찾기
        {
            // 같은 종류의 아이템 데이터고 슬롯에 빈용량이 있어야 한다.
            if(slot.ItemData == data && slot.ItemCount < slot.ItemData.maxStackCount)
            {
                findSlot = slot;
                break;
            }
        }
        return findSlot;
    }
}
