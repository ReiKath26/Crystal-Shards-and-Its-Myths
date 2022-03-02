using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossScript : MonoBehaviour
{
    public static FinalBossScript bossF;
    [Header("AttackPlayer")]
    [SerializeField] float attackPlayerSpeed;
    //[SerializeField] Transform player;
    public Transform player;
    public Transform returnposi;
    private Vector2 playerPosition;
    private bool hasPlayerPositon;
    public float stoppingDistance;

    private Rigidbody2D enemyRB;
    private Animator enemyAnim;
    private bool done = false;
    private bool facingLeft = true;
    public float damageMelee;

    public Transform meleePoint;
    public float meleerange = 0.8f;
    public LayerMask playerLayers;

    [Header("Tornadoooo")]
    private float timeBtwShots;
    public float startTimeBtwShot;

    public GameObject Tornados;


    public GameObject shadow;
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;

    private void Awake()
    {
        bossF = this;
    }

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShot;
    }

   
    void Update()
    {
        //attackPlayerMelee();
        //DeployTornado();
        SpawningShadow();
    }

    public void attackPlayerMelee()
    {
        done = false;
        if (done == false)
        {
            if (!hasPlayerPositon)
            {
                playerPosition = player.position - transform.position;
                playerPosition.Normalize();
                hasPlayerPositon = true;
            }
            if (hasPlayerPositon)
            {
                enemyRB.velocity = attackPlayerSpeed * playerPosition;

            }

            if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
            {
                enemyRB.velocity = Vector2.zero;
                enemyAnim.SetTrigger("melee");
                hasPlayerPositon = false;
                damagethem();
            }
        }
        
    }

    public void DeployTornado()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(Tornados, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShot;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void damagethem()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(meleePoint.position, meleerange, playerLayers);

        foreach (Collider2D playerz in hitPlayer)
        {
            Debug.Log("kena" + playerz.name);
            player.GetComponent<Health>().TakeDamage(damageMelee);
        } 
    }

    public void returnPos()
    {
        transform.position = returnposi.transform.position;
        done = true;
        
    }

    void randomstatepicker()
    {
        int randomstate = Random.Range(0, 2);
        if (randomstate == 0)
        {
            enemyAnim.SetTrigger("AttackOne");
        }
        if (randomstate == 1)
        {
            enemyAnim.SetTrigger("AttackTwo");
        }

    }

    public void SpawningShadow()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(99f, 108f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(shadow, whereToSpawn, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        if (meleePoint != null)
        {
            Gizmos.DrawWireSphere(meleePoint.position, meleerange);
        }
    }

}
