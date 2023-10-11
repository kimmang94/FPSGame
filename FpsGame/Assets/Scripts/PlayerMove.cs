using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private float _moveSpeed = 7f;
    private CharacterController cc;

    private float gravity = -20f;
    private float yVelocity = 0;
    [SerializeField] private float jumpPower = 10f;
    private bool isJumping = false;
    public int hp = 20;
    private int maxHp = 20;
    [SerializeField]private Slider hpSlider;
    [SerializeField] private GameObject hitEffect;
    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {       
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized;
        dir = Camera.main.transform.TransformDirection(dir);


        if (Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpPower;
        }
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;
        cc.Move(dir * _moveSpeed * Time.deltaTime);

        if (cc.collisionFlags == CollisionFlags.Below)
        {
            if (isJumping)
            {
                isJumping = false;
            }
        }

        hpSlider.value = (float)hp / (float)maxHp;
    }

    public void DamageAction(int damage)
    {
        hp -= damage;

        if (hp > 0)
        {
            StartCoroutine(PlayHitEffect());
        }
    }

    private IEnumerator PlayHitEffect()
    {
        hitEffect.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        hitEffect.SetActive(false);
    }
}
