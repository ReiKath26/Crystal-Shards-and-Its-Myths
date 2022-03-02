using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBulletProjectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public float damage;
    public LayerMask whatIsSolid;
    private Transform player;
    private Vector2 target;

    public GameObject destroyEffect;


    void Start()
    {
        Invoke("DestroyBullets", lifeTime);
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, target, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                //Debug.Log("Player Hit");
                hitInfo.collider.GetComponent<Health>().TakeDamage(damage);
            }
            DestroyBullets();
        }
        if (Health.enemyhealth.currentHealth <= 5)
        {
  
            MiniBossSlime.slime.startTimeBtwShot = 1;
            damage = 1;
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    //if (other.CompareTag("Player"))
    //    //{
    //    //    DestroyBullets();
    //    //}
    //    DestroyBullets();
    //}

    void DestroyBullets()
    {
        
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
