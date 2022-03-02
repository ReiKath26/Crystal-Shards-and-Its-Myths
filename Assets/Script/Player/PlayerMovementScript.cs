
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask groundLayer2;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalInput;
    public static PlayerMovementScript movement;
    public GameObject[] players;


    [Header ("SFX")]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip attackSound;

    private void Awake()
    {
        movement = this;
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        // DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalInput * speed,body.velocity.y);

        //flip player when moving left-right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            if (isGrounded() || isGrounded2())
            {
                Jump();
            }
        }
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
        anim.SetBool("grounded", isGrounded2());
    }

    private void Jump()
    {
        SoundManager.instance.PlaySound(jumpSound);
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        anim.SetTrigger("jump");
    }

    public void Shoot()
    {
        SoundManager.instance.PlaySound(attackSound);
        anim.SetTrigger("attack");
    }

    // private void OnLevelWasLoaded(int level)
    // {
    //     FindStartPos();


    //     players = GameObject.FindGameObjectsWithTag("Player");

    //     if(players.Length > 1)
    //     {
    //         Destroy(players[1]);
    //     }
    // }

    public void FindStartPos()
    {
        transform.position = GameObject.FindWithTag("StartPos").transform.position;
    }


    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size,0,Vector2.down,0.1f,groundLayer);
        return raycastHit.collider != null;
    }

    private bool isGrounded2()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer2);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x,0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && isGrounded2();
    }
}
