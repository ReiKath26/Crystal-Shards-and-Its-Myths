using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;


    void Start()
    {
        player3.gameObject.SetActive(true);
        player1.gameObject.SetActive(false);
        player2.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            if(player3.activeSelf)
            {
                player1.transform.position =  GameObject.Find("Jeremy").transform.position;
            }

            else if(player2.activeSelf)
            {
                player1.transform.position = GameObject.Find("Claude").transform.position;
            }

            player3.gameObject.SetActive(false);
            player1.gameObject.SetActive(true);
            player2.gameObject.SetActive(false);
        }

         if(Input.GetKey(KeyCode.Alpha2))
        {

             if(player3.activeSelf)
            {
                player2.transform.position =  GameObject.Find("Jeremy").transform.position;
            }

            else if(player1.activeSelf)
            {
                player2.transform.position = GameObject.Find("Alexa").transform.position;
            }

            player3.gameObject.SetActive(false);
            player1.gameObject.SetActive(false);
            player2.gameObject.SetActive(true);
        }

        if(Input.GetKey(KeyCode.Alpha3))
        {

              if(player2.activeSelf)
            {
                player3.transform.position =  GameObject.Find("Claude").transform.position;
            }

            else if(player1.activeSelf)
            {
                player3.transform.position = GameObject.Find("Alexa").transform.position;
            }

            player3.gameObject.SetActive(true);
            player1.gameObject.SetActive(false);
            player2.gameObject.SetActive(false);
        }


    }
}
