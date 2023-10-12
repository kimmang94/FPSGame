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
    
    // 피격 이펙트 오브젝트
    public GameObject bulletEffect;

    private ParticleSystem ps;
    private void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 좌클릭을 누르면
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            // RaycastHit 는 Struct
            RaycastHit hitInfo = new RaycastHit();

            // Ray를 발사후 부딪힌 물체가 있으면 피격 이펙트 표시
            if (Physics.Raycast(ray, out hitInfo))
            {
                // 피격 이펙트의 위치를 레이가 부딪힌 지점으로 이동
                bulletEffect.transform.position = hitInfo.point;
                
                // 피격 이펙트의 foward 방향을 Ray가 부딪힌 지점의 법선 벡터와 일치
                bulletEffect.transform.forward = hitInfo.normal;
                
                // 피격 이펙트 플레이
                ps.Play();
            }
        }
        
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
