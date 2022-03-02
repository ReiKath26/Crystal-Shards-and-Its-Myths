using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    [SerializeField] private int CrystalAmount;

    private void Update()
    {
        if (CrystalText.crystalAmount == CrystalAmount)
        {
            Destroy(gameObject);
        }
    }
}
