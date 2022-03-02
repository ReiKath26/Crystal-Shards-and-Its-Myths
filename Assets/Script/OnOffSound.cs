using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffSound : MonoBehaviour
{
    [SerializeField] GameObject soundOnIcon;
    [SerializeField] GameObject soundOffIcon;
    private bool muted = false;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }

        else
        {
            Load();
        }
        UpdateButton();
        AudioListener.pause = muted;
    }

    public void OnButtonPress()
    {
        if(muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }

        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateButton();
    }

    private void UpdateButton()
    {
        if(muted == false)
        {
            soundOnIcon.SetActive(true);
            soundOffIcon.SetActive(false);
        }

        else
        {
            soundOnIcon.SetActive(false);
            soundOffIcon.SetActive(true);
        }
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
