using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{

    [Header("Collider Parameter")]
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float colliderDistance;

    [Header("Attack Parameter")]
    [SerializeField] private float range;
    [SerializeField] private float damage;


    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float coolDownTimer = Mathf.Infinity;


    private void Update()
    {
        coolDownTimer += Time.deltaTime;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }

    public bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0,
            Vector2.left,
            0,
            playerLayer);

        return hit.collider != null;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

}
