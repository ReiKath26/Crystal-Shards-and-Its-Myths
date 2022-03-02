using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevelSavePrologue : MonoBehaviour
{
   public GameObject loadingScreen;
    public Slider slider;
    public int maxIndex;
    public GameObject areYouSure;
    
    public void LoadMenu()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt");

        if(maxIndex < levelAt)
        {
             areYouSure.SetActive(true);
        }

        else
        {
            PlayerPrefs.SetInt("levelAt", 1);
             StartCoroutine(LoadAsynchronously(1));
        }
     
    }

    IEnumerator LoadAsynchronously (int sceneindex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneindex);

        loadingScreen.SetActive(true);


        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }
}
