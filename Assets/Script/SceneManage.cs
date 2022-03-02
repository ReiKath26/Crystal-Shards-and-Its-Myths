using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManage : MonoBehaviour
{ 
    
    public GameObject loadingScreen;
    public Slider slider;
    
    public void LoadMenu(int sceneindex)
    {
        PlayerPrefs.SetInt("levelAt", sceneindex);
        Debug.Log(PlayerPrefs.GetInt("levelAt"));
        StartCoroutine(LoadAsynchronously(sceneindex));
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

    public void quit()
    {
        Application.Quit();
        Debug.Log("Game quit");
    }
}
