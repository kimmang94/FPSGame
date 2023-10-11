using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 발사위치
    public GameObject firePosition;
    
    // 투척 무기 오브젝트
    public GameObject bombFactory;
    
    // 투척 파워
    public float throwPower = 15f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 우클릭을 누르면
        if (Input.GetMouseButtonDown(1))
        {
            // 수류탄 오브젝트 생성
            GameObject bomb = Instantiate(bombFactory);
            // 생성위치를 발사위치로
            bomb.transform.position = firePosition.transform.position;

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
        }
    }
}
