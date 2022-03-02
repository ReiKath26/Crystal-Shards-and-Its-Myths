using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public int levelToLoad;
    public string sLevelToLoad;

    public bool useintToLoad = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name == "Claude")
        {
            LoadScene();
        }

        if(collisionGameObject.name == "Alexa")
        {
            LoadScene();
        }

        if(collisionGameObject.name == "Jeremy")
        {
            LoadScene();
        }
    }

    void LoadScene()
    {
        if(useintToLoad)
        {
            PlayerPrefs.SetInt("levelAt", levelToLoad);
            SceneManager.LoadScene(levelToLoad);
        }

        else
        {
            SceneManager.LoadScene(sLevelToLoad);
        }
    }

   
}
