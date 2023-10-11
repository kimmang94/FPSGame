using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    [SerializeField]
    private float _rotSpeed = 200f;

    private float mx = 0;
    private float my = 0;
    private void Start()
    {
        
    }


    private void Update()
    {
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");

        mx += mouse_X * _rotSpeed * Time.deltaTime;
        my += mouse_Y * _rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -90f, 90f);
        transform.eulerAngles = new Vector3(-my, mx, 0);

    }
}
