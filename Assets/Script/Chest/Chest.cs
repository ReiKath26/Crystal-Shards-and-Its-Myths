using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    [SerializeField] private int amount;
    private Animator anim;

    [Header("SFX")]
    [SerializeField] private AudioClip openSound;
    
    private bool isOpen = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    protected override void onCollect()
    {

        if (!collected)
        {
            collected = true;
            CrystalText.crystalAmount += amount;
            anim.SetTrigger("ranged");
            if (!isOpen)
            {
                SoundManager.instance.PlaySound(openSound);
                isOpen = true;
            }
        }
    }
}
