using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : Collectable
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] Health health;
    [SerializeField] CrystalText crystal;

    [Header("SFX")]
    [SerializeField] private AudioClip checkPointSound;

    protected override void onCollect()
    {

        if (!collected)
        {
            SoundManager.instance.PlaySound(checkPointSound);
            spawnPoint.position = transform.position;
            collected = true;
            SaveData.SaveCheckPoint(health, crystal, this);

        }
    }
}
