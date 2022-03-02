using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFlag : Collectable
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] Health health;
    [SerializeField] CrystalText crystal;
    private Animator anim;
    [Header("SFX")]
    [SerializeField] private AudioClip checkPointSound;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    protected override void onCollect()
    {

        if (!collected)
        {
            SoundManager.instance.PlaySound(checkPointSound);
            spawnPoint.position = transform.position;
            anim.SetBool("range" , true);
            collected = true;

            
        }
    }
}
