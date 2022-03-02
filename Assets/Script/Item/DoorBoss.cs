using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBoss : MonoBehaviour
{
    [SerializeField] Health Bosshealth;

    private void Update()
    {
        if (Bosshealth.currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
