using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchChecker : MonoBehaviour
{
    
    void Start()
    {
        PlayerPrefs.SetInt("Drag", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("Drag") == 9)
        {
            SceneManager.LoadScene(14);
        }
    }
}
