using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float rotSpeed = 300f;
    private float mx = 0;
    private float my = 0;

    void Start()
    {
        
    }

    private void Update()
    {
        // 1.마우스입력받기
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");

        // 회전값 변수에 마우스 입력 값만큼 미리 누적
        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime;
        
        // 마우스 상하이동 회전변수(my)의 값을 -90 ~ 90 도 사이로 제한
        my = Mathf.Clamp(my, -90f, 90f);
        // 2. 회전 방향으로 물체를 회전
        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}
