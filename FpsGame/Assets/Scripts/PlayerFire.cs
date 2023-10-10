using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private Transform firePos;
    [SerializeField] private GameObject bombFactory;
    private float throwPoer = 15f;
    [SerializeField] private GameObject bulletEff;
    [SerializeField]private ParticleSystem ps;

    private void Start()
    {
        ps = bulletEff.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePos.transform.position;

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throwPoer, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0))
        { 
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward * 100f);
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100f, Color.red);
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    //eFSM.HitEnemy(weaponPower);
                }
                else
                {
                    bulletEff.transform.position = hitInfo.point;
                    bulletEff.transform.forward = hitInfo.normal;
                    ps.Play();
                }

            }
        }
    }
}
