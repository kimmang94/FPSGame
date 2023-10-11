using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 사용자 입력 받기
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        // 2. 이동 방향 설정
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;
        
        // 2.1 메인 카메라를 기준으로 방향변환
        dir = Camera.main.transform.TransformDirection(dir);
        
        
        // 3. 이동 속도에 맞춰 이동
        transform.position += dir * moveSpeed * Time.deltaTime;
    }
}
