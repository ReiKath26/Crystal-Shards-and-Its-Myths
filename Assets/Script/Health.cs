using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public static Health playerhealth;
    public static Health enemyhealth;

    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    public GameObject deadEffect;


    [Header("SFX")]
    [SerializeField] private AudioClip deadSound;
    [SerializeField] private AudioClip hurtSound;

    [Header("BOSS health inc")]
    [SerializeField] Health Bosshealth;

    
    public GameObject healthBar;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        playerhealth = this;
        enemyhealth = this;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            SoundManager.instance.PlaySound(hurtSound);
            anim.SetTrigger("hurt");

        }
        else
        {
            if (!dead)
            {
                SoundManager.instance.PlaySound(deadSound);



                //player
                if (GetComponent<PlayerMovementScript>() != null)
                {
                    currentHealth = startingHealth;
                    
                    PlayerMovementScript.movement.FindStartPos();
                    Bosshealth.AddHealth(startingHealth);
                }


                //enemy
                if (GetComponentInParent<PyroPatrol>() != null)
                {
                    GetComponentInParent<PyroPatrol>().enabled = false;
                    DeadEffect();
                    dead = true;
                }

                if (GetComponent<Pyro>() != null)
                {

                    GetComponent<Pyro>().enabled = false;
                    DeadEffect();
                    dead = true;
                }

                if (GetComponentInParent<CrowPatrol>() != null)
                {
                    GetComponentInParent<CrowPatrol>().enabled = false;
                    DeadEffect();
                    dead = true;
                }

                if (GetComponent<Crow>() != null)
                {

                    GetComponent<Crow>().enabled = false;
                    DeadEffect();
                    dead = true;
                }

                if (GetComponent<MiniBossSlime>() != null)
                {

                    GetComponent<MiniBossSlime>().enabled = false;
                    DeadEffect();
                    Destroy(healthBar);
                    dead = true;
                }

                if (GetComponent<PyroGrandPriest>() != null)
                {

                    GetComponent<PyroGrandPriest>().enabled = false;
                    DeadEffect();
                    dead = true;
                }
                if (GetComponent<FinalBossScript>() != null)
                {
                    GetComponent<FinalBossScript>().enabled = false;
                    DeadEffect();
                    dead = true;
                }

                if (GetComponent<ShadowScript>() != null)
                {
                    GetComponent<ShadowScript>().enabled = false;
                    DeadEffect();
                    dead = true;
                }





            }

        }


    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private void Update()
    {
        

    }
    void DeadEffect()
    {
        Instantiate(deadEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
