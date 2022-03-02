using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectFound : MonoBehaviour
{
    public Text texttext;
    public GameObject gameObject;

    // Start is called before the first frame update
    void OnMouseDown()
    {
        texttext.text = "";
        gameObject.SetActive(true);
        PlayerPrefsHelper.increment_int("ObjectFound");
    }

    public static class PlayerPrefsHelper
    {
        public static void increment_int(string key)
        {
            PlayerPrefs.SetInt(key, PlayerPrefs.GetInt(key)+1);
        }
    }
}
