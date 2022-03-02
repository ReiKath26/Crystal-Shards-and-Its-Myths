using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollect : MonoBehaviour
{
    [SerializeField] private float healthValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(collision.GetComponent<Health>().currentHealth < 3) {
                collision.GetComponent<Health>().AddHealth(healthValue);
                Destroy(gameObject);
            }
            
        }
    }
}
