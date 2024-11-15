using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa;
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
        SceneManager.LoadScene(0);
        Player.Instance.PlayerStats.CurrentHealth = Player.Instance.PlayerStats.MaxHealth;
    }

    public void Reintentar()
    {
        SceneManager.LoadScene(1);
        Player.Instance.PlayerStats.CurrentHealth = Player.Instance.PlayerStats.MaxHealth;
    }
}
