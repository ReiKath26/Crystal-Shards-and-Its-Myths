using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button[] lvlButtons;
    public GameObject[] lockedButtons;
    public GameObject congrats;
    public GameObject[] counter;

    void Start()
    {
         int levelAt = PlayerPrefs.GetInt("levelAt"); 

         if(levelAt < 2)
         {
             for(int i=1; i<lvlButtons.Length; i++)
             {
                 lvlButtons[i].interactable = false;
             }

             for (int j=0; j<lockedButtons.Length; j++)
             {
                 lockedButtons[j].SetActive(true);
             }
         }

         else if(levelAt < 7)
         {
             for(int i=2; i<lvlButtons.Length; i++)
             {
                 lvlButtons[i].interactable = false;
             }

             for (int j=1; j<lockedButtons.Length; j++)
             {
                 lockedButtons[j].SetActive(true);
             }

         }

         else if(levelAt < 16)
         {
              for(int i=3; i<lvlButtons.Length; i++)
             {
                 lvlButtons[i].interactable = false;
             }

             for (int j=2; j<lockedButtons.Length; j++)
             {
                 lockedButtons[j].SetActive(true);
             }
         }

         else if(levelAt == 19)
         {
             congrats.SetActive(true);

             for(int i=0; i<lvlButtons.Length; i++)
             {
                 lvlButtons[i].interactable = true;
             }

             for (int j=0; j<lockedButtons.Length; j++)
             {
                 lockedButtons[j].SetActive(false);
             }
         }

    }
}
