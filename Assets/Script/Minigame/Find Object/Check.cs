using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Check : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("ObjectFound", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("ObjectFound") == 5)
        {
            SceneManager.LoadScene(22);
        }
    }
}
