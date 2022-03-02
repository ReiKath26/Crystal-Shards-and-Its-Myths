using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBottle : Collectable
{
    [SerializeField] private float healthValue;
    private Animator anim;
    public GameObject collectEffect;
    private bool isOpen = false;

    [Header("SFX")]
    [SerializeField] private AudioClip openSound;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    protected override void onCollect()
    {
        
        if (!collected)
        {
            
            anim.SetTrigger("ranged");
            
            if (!isOpen)
            {
                SoundManager.instance.PlaySound(openSound);
                isOpen = true;
            }
            if (Health.playerhealth.currentHealth < 3)
            {
                collected = true;
                
                if(collected == true)
                {
                    Health.playerhealth.AddHealth(healthValue);
                    CollectEffect();
                }
            }

        }
    }

    void CollectEffect()
    {
        Instantiate(collectEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
