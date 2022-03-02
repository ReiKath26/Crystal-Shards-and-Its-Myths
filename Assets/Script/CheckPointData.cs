using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointData : MonoBehaviour
{
   public int level;
   public Health health;
   public Transform position;
   public CrystalText crystalAmount;


   public CheckPointData(Health current, CrystalText crystal, CheckPoint lastCheckPoint)
   {
       level = PlayerPrefs.GetInt("levelAt");
       health = current;
       crystalAmount = crystal;
       position = lastCheckPoint.transform;
   }


}
