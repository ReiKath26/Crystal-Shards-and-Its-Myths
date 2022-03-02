using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Holder : MonoBehaviour, IDropHandler
{
    public RectTransform target;
    [SerializeField] private AudioClip audio;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<RectTransform>() == target)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            PlayerPrefsHelper.increment_int("Drag");
            SoundManager.instance.PlaySound(audio);
        }

        else
        {

        }
    }

    public static class PlayerPrefsHelper
    {
        public static void increment_int(string key)
        {
            PlayerPrefs.SetInt(key, PlayerPrefs.GetInt(key)+1);
        }
    }
}
