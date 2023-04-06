using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    // 축 기준 : 왼쪽 아래가 원점
    // 축 방향 : 오른쪽 x+, 위쪽 y+

    /// <summary>
    /// 그리드 맵의 X좌표
    /// </summary>
    public int x;

    /// <summary>
    /// 그리드 맵의 Y좌표
    /// </summary>
    public int y;

    /// <summary>
    /// A* 알고리즘용 G 값(시작점에서 이 노드까지 오는데 걸린 거리)
    /// </summary>
    public float G;

    /// <summary>
    /// A* 알고리즘용 H 값(이 노드에서 도착점까지의 예상 거리)
    /// </summary>
    public float H;

    /// <summary>
    /// A* 알고리즘으로 출발점에서 이 노드를 경유했을 때 목적지까지의 예상 거리
    /// </summary>
    public float F => G + H;

    /// <summary>
    /// A*알고리즘으로 경로를 계산했을 때 앞에 있는 노드
    /// </summary>
    public Node parent;

    /// <summary>
    /// 노드의 종류를 나열해 놓은 열거형
    /// </summary>
    public enum GridType
    {
        Plain = 0,  // 평지(이동가능)
        Wall,       // 벽(이동불가능)
        Monster     // 슬라임(이동불가능)
    }

    /// <summary>
    /// 노드의 종류
    /// </summary>
    public GridType gridType = GridType.Plain;
}
