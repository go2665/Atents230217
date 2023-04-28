using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DetailWindow : MonoBehaviour
{
    public float alphaChangeSpeed = 5.0f;
    float alphaTarget = 0.0f;

    bool isPause = false;
    public bool IsPause
    {
        get => isPause;
        set
        {
            isPause = value;
            if(isPause)
            {
                Close();
            }
        }
    }

    Image itemIcon;
    TextMeshProUGUI itemName;
    TextMeshProUGUI itemPrice;
    TextMeshProUGUI itemDescription;

    CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        Transform child = transform.GetChild(0);
        itemIcon = child.GetComponent<Image>();
        child = transform.GetChild(1);
        itemName = child.GetComponent<TextMeshProUGUI>();
        child = transform.GetChild(2);
        itemPrice = child.GetComponent<TextMeshProUGUI>();
        child = transform.GetChild(3);
        itemDescription = child.GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if( alphaTarget > 0.0f )
        {
            canvasGroup.alpha += Time.deltaTime * alphaChangeSpeed;
        }
        else
        {
            canvasGroup.alpha -= Time.deltaTime * alphaChangeSpeed;
        }
        canvasGroup.alpha = Mathf.Clamp(canvasGroup.alpha, 0.0f, 1.0f);
    }

    public void Open(ItemData data)
    {
        if(!isPause && data != null)
        {
            itemIcon.sprite = data.itemIcon;
            itemName.text = data.itemName;
            itemPrice.text = data.price.ToString();
            itemDescription.text = data.itemDescription;

            alphaTarget = 1;
        }
    }

    public void Close()
    {
        alphaTarget = 0;
    }

    /// <summary>
    /// 상세 정보창의 위치를 옮기는 함수
    /// </summary>
    /// <param name="screenPos">새 위치(스크린 좌표)</param>
    public void MovePosition(Vector2 screenPos)
    {
        if (canvasGroup.alpha > 0)  // 보일때만 움직이게 하기
        {
            RectTransform rect = (RectTransform)transform;

            int diffX = (int)(screenPos.x + rect.sizeDelta.x) - Screen.width;
            diffX = Mathf.Max(0, diffX);    // 넘친부분만큼만 왼쪽으로 보내기
            screenPos.x -= diffX;           // 화면을 안벗어나게 만들기

            //if (screenPos.x + rect.sizeDelta.x > Screen.width)   // 가로로 벗어난 경우
            //{
            //    screenPos.x -= rect.sizeDelta.x;                // 디테일창 가로 크기만큼 왼쪽으로 보내기
            //}
            //if (screenPos.y - rect.sizeDelta.y < 0)             // 세로로 벗어난 경우
            //{
            //    screenPos.y += rect.sizeDelta.y;                // 디테일창 세로 크기만큼 위로 보내기
            //}

            transform.position = screenPos;     // 위치 변경
        }
    }
}
