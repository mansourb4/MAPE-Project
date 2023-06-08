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

    public int maxHealth;
    public int currentHealth;
    
    public HealthBar healthBar;
    public int nbAttackPotion = 0;
    public bool armor = false;
    public bool boots = false;
    public int toHeal = 0;

    private bool _instantiated=false;

    void Start()
    {
        playerName = CharacterMenu.Instance.GetPlayerName();
        switch (playerName)
        {
            case "Akomi":
                playerAkomi = Instantiate(playerAkomi, new Vector3(83, -30, 0), Quaternion.identity);
                playerTransform = playerAkomi.transform;
                _instantiated = true;
                break;
            case "Gentaro":
                playerGentaro = Instantiate(playerGentaro, new Vector3(83, -30, 0), Quaternion.identity);
                playerTransform = playerGentaro.transform;
                _instantiated = true;
                break;
            case "Heira":
                playerHeira = Instantiate(playerHeira, new Vector3(83, -30, 0), Quaternion.identity);
                playerTransform = playerHeira.transform;
                _instantiated = true;
                break;
            case "Kettewen":
                playerKettewen = Instantiate(playerKettewen, new Vector3(83, -30, 0), Quaternion.identity);
                playerTransform = playerKettewen.transform;
                _instantiated = true;
                break;
            default:
                break;
        }

        healthBar.SetMaxHealth(maxHealth);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemies");
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<Enemycombats>().FindPlayer();
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!_instantiated)
        {
            Start();

        }
        
    }
}
