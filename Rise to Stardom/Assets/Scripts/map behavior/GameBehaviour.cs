using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    public bool estPuertas = false;
    public int roomEnemy;
    public bool boss;
    public bool enemiesSpawnedInRoom = false;

    public HUD hud;

    public static GameBehaviour Instance { get; private set; }
    public int Coins { get; private set;}

    void Start()
    {
        boss = false;
        roomEnemy = 0;
    }

    void Update()
    {
        if (boss)
        {
            SceneManager.LoadScene(3);
        }

        if (Player.Instance.PlayerStats.CurrentHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("mas de 1 gameManager");
        }
    }
    public void AddCoins(int totalCoins)
    {
        Coins += totalCoins;
        hud.UpdateCoins(Coins);
    }

    public void IncrementEnemyCount()
    {
        roomEnemy++;
    }
    public void DecrementEnemyCount()
    {
        if (roomEnemy > 0)
        {
            roomEnemy--;
        }
    }
}
