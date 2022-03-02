using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    [SerializeField] private Health playerHeatlh;
    [SerializeField] private float totalHealth;
    Text healthText;
    private float health;

    private void Start()
    {
        healthText = GetComponent<Text>();
    }

    private void Update()
    {
        health = playerHeatlh.currentHealth;
        healthText.text = health.ToString() + " / " + totalHealth;
    }
}
