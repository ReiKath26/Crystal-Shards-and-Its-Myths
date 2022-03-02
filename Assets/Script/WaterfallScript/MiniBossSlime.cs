using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossSlime : MonoBehaviour
{
    public static MiniBossSlime slime;
    private Transform player;
    private float timeBtwShots;
    public float startTimeBtwShot;

    public GameObject slimeBullet;

    private Animator anim;

    private void Awake()
    {
        slime = this;

        anim = GetComponent<Animator>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShot;
    }

    void Update()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(slimeBullet, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShot;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        if (Health.enemyhealth.currentHealth <= 5)
        {
            anim.SetBool("angry", true);
        }

    }


}
