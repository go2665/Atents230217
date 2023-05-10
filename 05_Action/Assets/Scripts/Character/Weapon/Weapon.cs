using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    CapsuleCollider blade;

    private void Awake()
    {
        blade = GetComponent<CapsuleCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log($"{other.name}을 공격했다.");
        }
    }

    public void ColliderEnable(bool enable)
    {
        blade.enabled = enable;
    }
}
