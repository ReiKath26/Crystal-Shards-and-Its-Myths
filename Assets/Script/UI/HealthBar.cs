using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHeatlh;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    [SerializeField] private float totalHealth;

    private void Start()
    {
        totalHealthBar.fillAmount = playerHeatlh.currentHealth / totalHealth;
    }
    private void Update()
    {
        
        currentHealthBar.fillAmount = playerHeatlh.currentHealth / totalHealth; 

    }
}
