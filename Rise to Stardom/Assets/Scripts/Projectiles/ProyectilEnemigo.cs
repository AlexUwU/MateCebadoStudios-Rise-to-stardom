using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilEnemigo : ProyectilBase
{
    public override void OnTriggerEnter(Collider jugador)
    {
        if (jugador.tag == "Player")
        {
            Debug.Log("A");
            ProtagonistaEstadisticas vidaJugador = objetivo.gameObject.GetComponent<ProtagonistaEstadisticas>();
            if (vidaJugador != null)
                vidaJugador.RecibirDmg(damage);
            Destroy(gameObject);
        }
    }
}
