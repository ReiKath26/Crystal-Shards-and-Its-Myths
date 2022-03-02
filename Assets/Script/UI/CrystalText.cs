using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalText : MonoBehaviour
{
    Text crystalText;
    public static int crystalAmount;
    [SerializeField] private int CrystalAmountMustCollect;

    private void Start()
    {
        crystalAmount = 0;
        crystalText = GetComponent<Text>();
    }

    private void Update()
    {
        crystalText.text = crystalAmount.ToString() + " / " + CrystalAmountMustCollect ;
    }
}
