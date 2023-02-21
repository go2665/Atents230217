using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10.0f;

    private void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    private void Update()
    {
        // 초당 speed의 속도로 오른쪽방향으로 이동(로컬 좌표를 기준으로 한 방향)
        //transform.Translate(Time.deltaTime * speed * Vector2.right); 
        //transform.Translate(Time.deltaTime * speed * transform.right, Space.World); 
        transform.position += Time.deltaTime * speed * transform.right;

        // local좌표와 world좌표
        // local좌표 : 각 오브젝트 별 기준으로 한 좌표계
        // world좌표 : 맵을 기준으로 한 좌표계
    }
}
