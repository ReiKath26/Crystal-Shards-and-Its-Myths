using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WrongAnswer : MonoBehaviour
{
    public GameObject next, prev;

    public void WrongChoice()
    {
        next.SetActive(true);
        prev.SetActive(false);
    }

    public void nextScene()
    {
        SceneManager.LoadScene(29);
    }
}
