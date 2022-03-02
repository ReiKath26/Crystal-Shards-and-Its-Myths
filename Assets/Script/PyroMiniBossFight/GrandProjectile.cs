using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandProjectile : MonoBehaviour
{
    public static GrandProjectile Grands;
    [Header("Other")]
    [SerializeField] Transform groundCheckUp;
    [SerializeField] Transform groundCheckDown;
    [SerializeField] Transform groundCheckWall;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;


    private bool isTouchingUp;
    private bool isTouchingDown;
    private bool isTouchingWall;
    private Rigidbody2D bulletRB;
    private bool goingUp = true;
    private bool facingleft = true;
    private GameObject bullet;

   
    [SerializeField] float speed;
    [SerializeField] Vector2 target1;
    private Vector2 target2;
    public float lifeTime;
    public float distance;
    public float damage;
    public LayerMask whatIsSolid;
    private Transform player;
    //private Vector2 target;
    private bool ysss;

    public GameObject destroyEffect;

    private void Awake()
    {
        Grands = this;
    }

    void Start()
    {
        Invoke("DestroyBullets", lifeTime);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target2 = new Vector2(player.position.x, player.position.y);

        target1.Normalize();
        bulletRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        isTouchingUp = Physics2D.OverlapCircle(groundCheckUp.position, groundCheckRadius, groundLayer);
        isTouchingDown = Physics2D.OverlapCircle(groundCheckDown.position, groundCheckRadius, groundLayer);
        isTouchingWall = Physics2D.OverlapCircle(groundCheckWall.position, groundCheckRadius, groundLayer);

        //if (PyroGrandPriest.pyrogrand.GetComponent<Health>().currentHealth > 5)
        //{
        //    AttackTwoState();

        //}
        //else if (PyroGrandPriest.pyrogrand.GetComponent<Health>().currentHealth <= 5)
        //{
        //    AttackStateOne();
        //}

        AttackStateOne();

    }

    public void Idle()
    {

        if (GrandProjectile.Grands != null)
        {
            PyroGrandPriest.pyrogrand.startTimeBtwShot = 10;
            Destroy(gameObject);
        }
        
    }

    public void AttackStateOne()
    {
        if (bulletRB != null)
        {
            lifeTime = 5;
            speed = 20;
            PyroGrandPriest.pyrogrand.startTimeBtwShot = 1;
            if (isTouchingUp && goingUp)
            {
                ChangeDirection();
            }
            else if (isTouchingDown && !goingUp)
            {
                ChangeDirection();
            }
            if (isTouchingWall)
            {
                if (facingleft)
                {
                    FlipDirection();
                }
                else if (!facingleft)
                {
                    FlipDirection();
                }

            }

            bulletRB.velocity = speed * target1;
        }
        
    }

    public void AttackTwoState()
    {
        if (bulletRB != null)
        {
            bulletRB.isKinematic = true;
            transform.position = Vector2.MoveTowards(transform.position, target2, speed * Time.deltaTime);
            lifeTime = 2;
            speed = 20;
            PyroGrandPriest.pyrogrand.startTimeBtwShot = 2;
            
        }
        
    }

    private void ChangeDirection()
    {
        goingUp = !goingUp;
        target1.y *= -1;
    }

    private void FlipDirection()
    {
        facingleft = !facingleft;
        target1.x *= -1;
        transform.Rotate(0, 180, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(groundCheckUp.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckDown.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckWall.position, groundCheckRadius);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            DestroyBullets();
        }

    }


    void DestroyBullets()
    {

        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }
}
