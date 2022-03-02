using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSave : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    public Health player1health;
    public Health player2health;
    public Health player3health;
    public CrystalText crystal;

    void Start()
    {
        CheckPointData data = SaveData.LoadCheckPoint();

        if(PlayerPrefs.GetInt("levelAt") == data.level)
        {
            player1health = data.health;
            player2health = data.health;
            player3health = data.health;

            crystal = data.crystalAmount;
            spawnPoint.transform.position = data.position.position;
        }
    }


}
