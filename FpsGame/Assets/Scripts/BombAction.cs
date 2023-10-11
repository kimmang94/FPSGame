using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;
    private void OnCollisionEnter(Collision other)
    {
        GameObject eff = Instantiate(bombEffect);
        
        // 이펙트 프리팹의 위치는 수류탄 오브젝트의 위치
        eff.transform.position = transform.position;
        Destroy(gameObject);
    }
}
