using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public float damage;


    // Update is called once per frame
    void Update()
    {
        if(timeBtwAttack <=0)
        {
            if(Input.GetMouseButton(0))
            {
                timeBtwAttack = startTimeBtwAttack;
                PlayerMovementScript.movement.Shoot();
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for(int i = 0; i<enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Health>().TakeDamage(damage);
                }
            }

        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        } 
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
