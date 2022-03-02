using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckpoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }
}
