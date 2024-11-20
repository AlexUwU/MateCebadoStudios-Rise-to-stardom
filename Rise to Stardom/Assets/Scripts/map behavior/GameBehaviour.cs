using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    public bool estPuertas = false;
    public Transform inicioSala;
    public int roomEnemy;
    public bool boss;
    public bool enemiesSpawnedInRoom = false;
    [SerializeField] Camera cam;
    [SerializeField] Transform primeraSala;
    public HUD hud;

    public static GameBehaviour Instance { get; private set; }
    public int Coins { get; private set;}

    void Start()
    {
        boss = false;
        roomEnemy = 0;
        Vector3 camaraPosicionInicial = new Vector3(primeraSala.transform.position.x, primeraSala.transform.position.y+18, primeraSala.transform.position.x-13.5f);
        cam.transform.position = camaraPosicionInicial;
        //cam.transform.LookAt(primeraSala);
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
