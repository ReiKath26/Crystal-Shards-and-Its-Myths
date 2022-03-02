using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2Player : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        player1.gameObject.SetActive(false);
        player2.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            player1.transform.position =  GameObject.Find("Claude").transform.position;
            player1.gameObject.SetActive(true);
            player2.gameObject.SetActive(false);
        }

         if(Input.GetKey(KeyCode.Alpha2))
        {
            
            
            player2.transform.position = GameObject.Find("Alexa").transform.position;
            player1.gameObject.SetActive(false);
            player2.gameObject.SetActive(true);
        }
    }
}
