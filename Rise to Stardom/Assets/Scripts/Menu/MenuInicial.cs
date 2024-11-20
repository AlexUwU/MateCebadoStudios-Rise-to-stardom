using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public GameObject panelInicial;
    public void Jugar()
    {
        SceneManager.LoadScene(1);
        panelInicial.SetActive(false);
    }

    public void Salir()
    {
        Debug.Log("Salir");
        Application.Quit();
    }
}
