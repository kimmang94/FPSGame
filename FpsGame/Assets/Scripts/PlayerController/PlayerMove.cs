using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 7f;
    private CharacterController cc;
    private float gravity = -20f;
    private float yVelocity = 0; // y축 속도
    public float jumpPower = 10f;
    public bool isJumping = false;
    
    void Start()
    {
        cc = GetComponent<CharacterController>();
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
        
        // 만약 다시 바닥에 착지했다면
        // CollisionFlag.Below 는 컨트롤러 하단에 충돌할경우 true
        // Above 는 위
        // Side 는 옆쪽 일경우 true
        if (cc.collisionFlags == CollisionFlags.Below)
        {
            if (isJumping)
            {
                isJumping = false;
                yVelocity = 0;
            }
            
        // Jump 키를 누르면
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            // 캐릭터 수직속도에 점프력 더하기
            yVelocity = jumpPower;
            isJumping = true;
        }

       
        }
        
        // 2.2 캐릭터 수직 속도에 중력 값을 적용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        
        // 3. 이동 속도에 맞춰 이동 Move() 는 CharacterController 안에 내장된 함수
        cc.Move(dir * moveSpeed * Time.deltaTime);
    }
}
