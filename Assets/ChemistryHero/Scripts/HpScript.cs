using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HpScript : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    CameraPointer Player;

    // Start is called before the first frame update
    private void Start()
    {
        HealthBar = GetComponent<Image>();
        Player = FindObjectOfType<CameraPointer>();
    }

    // Update is called once per frame
    private void Update()
    {
        CurrentHealth = Player.Health;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}