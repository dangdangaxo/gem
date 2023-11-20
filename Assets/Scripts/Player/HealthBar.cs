using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    
    HealthPlayer playerStatus;
    public Slider healthBar;
    public Image health;
    void Start()
    {
        playerStatus = FindObjectOfType<HealthPlayer>();
        healthBar = GetComponent<Slider>();
    }

    void Update()
    {
        healthBarState();
    }

    void healthBarState()
    {
        healthBar.value = playerStatus.Health;
        if (healthBar.value <= 50)
        {
            health.color = new Color32(225,225,225,100);
        }
    }
}
