using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemCode
{
    Ruby = 0,
    Emerald,
    Sapphire
}

public enum ItemSortBy
{
    ID,     // ID 기준으로 정렬
    Name,   // 이름 기준
    Price   // 가격 기준
}

public class ItemDataManager : MonoBehaviour
{
    public ItemData[] itemDatas = null;

    public ItemData this[uint id] => itemDatas[id];

    public ItemData this[ItemCode code] => itemDatas[(int)code];

    public int length => itemDatas.Length;
}