using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCountText : MonoBehaviour
{
    public float speed = 1.0f;
    float targetValue = 1.0f;
    float currentValue = 1.0f;

    TextMeshProUGUI killCount;

    private void Awake()
    {
        killCount = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        Player player = GameManager.Inst.Player;
        player.onKillCountChange += OnKillCountChange;
        targetValue = 0;
        currentValue = 0;
    }

    private void Update()
    {
        // 킬카운트는 무조건 증가만 진행됨
        currentValue += Time.deltaTime * speed; // 무조건 계속 증가
        if( currentValue > targetValue)         // 목표치를 넘어서면
        {
            currentValue = targetValue;         // 목표치로 설정
        }
        int temp = (int)currentValue;   
        killCount.text = temp.ToString();       // 인티저로 변경해서 소수점 날리고 그대로 출력
    }

    private void OnKillCountChange(int count)
    {
        targetValue = count;    // 목표치 설정
    }
}
