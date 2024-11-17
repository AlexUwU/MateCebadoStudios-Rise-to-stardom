using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    [SerializeField] Camera cam;
    public Transform inicioSala;
    public bool estPuertas = false;
    public int roomEnemy;
    public bool boss;

    [SerializeField] Camera cam;
    [SerializeField] Transform primeraSala;

    public HUD hud;

    public static GameBehaviour Instance { get; private set; }
    public int Coins { get; private set;}

    void Start()
    {
        boss = false;
        roomEnemy = 0;
<<<<<<< Updated upstream
        cam.transform.LookAt(inicioSala);
=======
        Vector3 camaraPosicionInicial = new Vector3(primeraSala.transform.position.x, primeraSala.transform.position.y+15, primeraSala.transform.position.x-14.5f);
        cam.transform.position = camaraPosicionInicial;
        cam.transform.LookAt(primeraSala);
>>>>>>> Stashed changes
    }

    void Update()
    {
        if (boss)
        {
            SceneManager.LoadScene(3);
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


}
