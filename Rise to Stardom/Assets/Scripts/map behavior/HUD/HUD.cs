using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject[] vidas;
    public TextMeshProUGUI coins;

    public GameObject corazon;
    //public GameObject corazonesTransform;
    public int cantLives;
    public PersonajeEstadisticas stadsPj;

    public Estadisticas vidaMaxima;

    public float vidaFaltante = 0;

    void Start()
    {
        stadsPj = FindObjectOfType<PersonajeEstadisticas>();
        cantLives = vidas.Length;
    }
    void Update()
    {
        
        coins.text = GameBehaviour.Instance.Coins.ToString();
    }
    public void UpdateCoins(int Coins)
    {
        coins.text = Coins.ToString();
    }

    public void DisabledLives(int indice)
    {
        vidas[indice-1].SetActive(false);
    }

    public void ActivateLives(int indice)
    {
        vidas[indice].SetActive(true);
    }
}
