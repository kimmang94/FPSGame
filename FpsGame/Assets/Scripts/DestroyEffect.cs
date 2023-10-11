using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    // 제거될 시간
    public float destroyTime = 1.5f;
    // 경과 시간 측정
    private float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 경과시간이 제거시간을 초과하면 제거
        if (currentTime > destroyTime)
        {
            Destroy(gameObject);
        }

        currentTime += Time.deltaTime;
    }
}
