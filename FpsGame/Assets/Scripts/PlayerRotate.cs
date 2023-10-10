using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private float _rotSpeed = 200f;

    private float mx = 0;
    private void Start()
    {
        
    }

    private void Update()
    {
        float mouse_X = Input.GetAxis("Mouse X");

        mx += mouse_X * _rotSpeed * Time.deltaTime;

        transform.eulerAngles = new Vector3(0, mx, 0);
    }
}
