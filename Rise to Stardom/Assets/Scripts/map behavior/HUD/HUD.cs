using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject[] vidas;
    public TextMeshProUGUI coins;

    public PersonajeEstadisticas stadsPj;
    public int cantLives;
    public float vidaPorCorazon;

    void Start()
    {
        stadsPj = FindObjectOfType<PersonajeEstadisticas>();
        cantLives = vidas.Length;
        vidaPorCorazon = Player.Instance.PlayerStats.MaxHealth / cantLives;
        UpdateLives();
    }

    void Update()
    {
        coins.text = GameBehaviour.Instance.Coins.ToString();
        UpdateLives();
    }

    public void UpdateCoins(int Coins)
    {
        coins.text = Coins.ToString();
    }

    public void UpdateLives()
    {
        float currentHealth = Player.Instance.PlayerStats.CurrentHealth;

        for (int i = 0; i < cantLives; i++)
        {
            if (currentHealth > i * vidaPorCorazon)
            {
                vidas[i].SetActive(true);
            }
            else
            {
                vidas[i].SetActive(false);
            }
        }
    }
}
