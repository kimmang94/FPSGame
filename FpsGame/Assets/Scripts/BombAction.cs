using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAction : MonoBehaviour
{
    [SerializeField] private GameObject bombEffect;
    private void OnCollisionEnter(Collision other)
    {
        GameObject eff = Instantiate(bombEffect);
        eff.transform.position = transform.position;
        Destroy(gameObject);
    }
}
