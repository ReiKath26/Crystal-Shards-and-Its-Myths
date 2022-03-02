using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource daMusic;

    public bool startPlaying;
    
    public BeatScroller daBS;

    public static GameManager instance;

    public int score;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNoter = 150;

    public int mult;
    public int multTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiText;

    public GameObject your_result;
    public Text grade;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        mult = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                daBS.started = true;

                daMusic.Play();
            }
        }

        else
        {
            if(!daMusic.isPlaying)
            {
                grade.text = countScore();
                your_result.SetActive(true);

                if(Input.anyKeyDown)
                {
                    SceneManager.LoadScene(24);
                }
            }
        }
    }

    public string countScore()
    {
        if(score>=65000)
        {
            return "S";
        }

        else if(score>=50000)
        {
            return "A";
        }

        else if(score>=40000)
        {
            return "B";
        }

        else
        {
            return "C";
        }
    }

    public void NoteHit()
    {

        if(mult - 1 < multiplierThresholds.Length)
        {
            multTracker++;

          if(multiplierThresholds[mult - 1] <= multTracker)
          {
            multTracker = 0;
            mult++;
          }
        }

        multiText.text = "Multiply x" + mult;
        
        // score += scorePerNote * mult;
        scoreText.text = "Score: " + score;
    }

    public void NormalHit()
    {
        score += scorePerNote * mult;
        NoteHit();
    }

    public void GoodHit()
    {
        score += scorePerGoodNote * mult;
        NoteHit();
    }

    public void PerfectHit()
    {
        score += scorePerPerfectNoter * mult;
        NoteHit();
    }

    public void NoteMissed()
    {

        mult = 1;
        multTracker = 0;

        multiText.text = "Multiply x" + mult;
    }
}
