using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CorrectAnswer : MonoBehaviour
{
    public GameObject next, prev;

    public void CorrectChoice()
    {
        PlayerPrefsHelper.increment_int("Correct_answer");
        next.SetActive(true);
        prev.SetActive(false);

    }

     public static class PlayerPrefsHelper
    {
        public static void increment_int(string key)
        {
            PlayerPrefs.SetInt(key, PlayerPrefs.GetInt(key)+1);
        }
    }

    public void nextScene()
    {
        PlayerPrefsHelper.increment_int("Correct_answer");
        SceneManager.LoadScene(29);
    }
}
