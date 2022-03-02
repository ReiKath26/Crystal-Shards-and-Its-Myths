using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossSlimeBehaviour : MonoBehaviour
{
    public enum Stage
    {
        Stage_1,
        Stage_2,
        Stage_3,
    }

    private Stage stage;

    private void Awake()
    {
        stage = Stage.Stage_1;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void MinibossOnDamaged(object sender, System.EventArgs e)
    {
        switch (stage)
        {
            case Stage.Stage_2:
                if (Health.enemyhealth.currentHealth < 5)
                {
                    StartNextStage();
                }
                break;
        }
    }
    private void StartNextStage()
    {
        switch (stage)
        {
            case Stage.Stage_1:
                stage = Stage.Stage_2;
                break;
        }
        Debug.Log("Starting next stage: " + stage);
    }
    private void startBattle()
    {
        Debug.Log("StartBattle");
        
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
