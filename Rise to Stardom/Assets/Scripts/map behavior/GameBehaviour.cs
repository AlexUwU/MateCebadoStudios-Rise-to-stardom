using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    public bool estPuertas = false;
    public int roomEnemy;

    public HUD hud;

    public static GameBehaviour Instance { get; private set; }
    public int Coins { get; private set;}

    void Start()
    {
        roomEnemy = 0;
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


}
