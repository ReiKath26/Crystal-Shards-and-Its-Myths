using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoProjectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public float damage;
    private Vector2 target;
    public LayerMask whatIsSolid;
    private Transform player;

    public GameObject destroyEffect;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    private void Update()
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
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
