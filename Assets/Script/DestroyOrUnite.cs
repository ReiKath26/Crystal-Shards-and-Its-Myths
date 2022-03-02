using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestroyOrUnite : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;

    void Start()
    {
        PlayerPrefs.SetInt("choice", 0);
    }

    public void Destroy()
    {
        PlayerPrefs.SetInt("choice", 1);
        StartCoroutine(LoadAsynchronously(13));
    }

    public void Unite()
    {
        PlayerPrefs.SetInt("choice", 2);
        StartCoroutine(LoadAsynchronously(14));
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
