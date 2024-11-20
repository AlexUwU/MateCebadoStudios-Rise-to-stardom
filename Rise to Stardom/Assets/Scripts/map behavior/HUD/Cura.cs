using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cura : MonoBehaviour
{
    public HUD hud;

    public PersonajeEstadisticas stadsPj;
    public Estadisticas vidaMaxima;

    void Start()
    {
        stadsPj = FindObjectOfType<PersonajeEstadisticas>();
        hud = FindObjectOfType<HUD>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (stadsPj.vidaActual < vidaMaxima.GetValor())
            {
                stadsPj.Curar();
                hud.cantLives++;
                //hud.ActivateLives(hud.cantLives);
                Destroy(this.gameObject);
            }
        }
        else
        {
            Debug.Log("vida llena");
        }
    }
}
