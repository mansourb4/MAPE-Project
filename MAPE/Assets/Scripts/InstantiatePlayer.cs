using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiatePlayer : MonoBehaviour
{
    public static InstantiatePlayer Instance;

    private void Awake() => Instance = this;

    public GameObject playerAkomi;
    public GameObject playerGentaro;
    public GameObject playerHeira;
    public GameObject playerKettewen;

    public string playerName;
    
    public Transform playerTransform;

    public int maxHealth = 100;
    public int currentHealth;
    
    public HealthBar healthBar;

    void Start()
    {
        playerName = MainMenu.instance.playerName;
        switch (playerName)
        {
            case "Akomi":
                playerAkomi = Instantiate(playerAkomi, new Vector3(83, -37, 0), Quaternion.identity);
                playerTransform = playerAkomi.transform;
                break;
            case "Gentaro":
                playerGentaro = Instantiate(playerGentaro, new Vector3(83, -37, 0), Quaternion.identity);
                playerTransform = playerGentaro.transform;
                break;
            case "Heira":
                playerHeira = Instantiate(playerHeira, new Vector3(83, -37, 0), Quaternion.identity);
                playerTransform = playerHeira.transform;
                break;
            case "Kettewen":
                playerKettewen = Instantiate(playerKettewen, new Vector3(83, -37, 0), Quaternion.identity);
                playerTransform = playerKettewen.transform;
                break;
            default:
                throw new Exception("Wrong character exception");
        }

        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
