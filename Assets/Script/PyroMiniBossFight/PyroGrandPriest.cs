using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyroGrandPriest : MonoBehaviour
{
    public static PyroGrandPriest pyrogrand;
    private Transform player;
    private float timeBtwShots;
    public float startTimeBtwShot;
    private Animator setanim;

    public GameObject slimeBullet;

    private void Awake()
    {
        pyrogrand = this;
        setanim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("ShootatThis").transform;
        timeBtwShots = startTimeBtwShot;
    }

    // Update is called once per frame
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

        if (GetComponent<Health>().currentHealth <= 5)
        {
            Debug.Log(GetComponent<Health>().currentHealth);
            setanim.SetTrigger("fire");

        }
    }
}
