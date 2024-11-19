using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogWarning("No se encontro");
        }
    }
    void Update()
    {
        Pausa();
    }

    private void Pausa()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            menuPausa.SetActive(true);
        }
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
    }

    public void MenuPrincipal()
    {
        if (player != null)
        {
            Destroy(player);
        }

        SceneManager.LoadScene(0);
    }

    public void Reintentar()
    {

        if (player != null)
        {
            Destroy(player);
        }

        SceneManager.LoadScene(1);
    }
}
