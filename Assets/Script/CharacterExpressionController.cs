using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterExpressionController : MonoBehaviour
{
    public GameObject[] openSprite;
    public GameObject[] closeSprite;
    public int nextScene;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            NextSprite();
        }
    }

    public void NextSprite()
    {
        if(index< openSprite.Length - 1)
        {
            index++;
            openSprite[index].SetActive(true);
            closeSprite[index].SetActive(false);
        }

        else
        {
            ChangeScene(nextScene); 

            if(nextScene!=0)
            {
                 PlayerPrefs.SetInt("levelAt", nextScene);
            }

            else
            {
                PlayerPrefs.SetInt("levelAt", 19);
            }
           
        }
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
