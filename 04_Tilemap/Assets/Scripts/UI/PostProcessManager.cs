using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessManager : MonoBehaviour
{
    /// <summary>
    /// 포스트 프로세스용 볼륨
    /// </summary>
    Volume postProcessVolume;

    /// <summary>
    /// 볼륨에 들어있을 비네트 효과를 사용하기 위한 클래스의 객체
    /// </summary>
    Vignette vignette;

    private void Awake()
    {
        postProcessVolume = GetComponent<Volume>();
        postProcessVolume.profile.TryGet<Vignette>(out vignette);   // 찾기. 없으면 null이 설정되고 있으면 null 아닌 값
    }

    private void Start()
    {
        Player player = GameManager.Inst.Player;
        player.onLifeTimeChange += OnLifeTimeChange;    // 플레이어의 수명 변경 델리게이트에 함수 등록
        vignette.intensity.value = 0;   // 초기화
    }

    private void OnLifeTimeChange(float ratio)
    {
        vignette.intensity.value = 1.0f - ratio;        // 수명 변할 때마다 비네트 정도 변경
    }
}
