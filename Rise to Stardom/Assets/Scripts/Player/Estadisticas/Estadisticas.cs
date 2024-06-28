using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Estadisticas
{
    [SerializeField] private float valorBaseEstadistica;
    private List<float> modificadores = new List<float>();
    public float GetValor()
    {
        float valorFinal = valorBaseEstadistica;
        modificadores.ForEach(x => valorFinal += x);
        if (valorFinal <= 0)
            valorFinal = 0.01f;

        return valorFinal;
    }
    public void AddModificador(float modificador)
    {
        if(modificador != 0)
            modificadores.Add(modificador);
    }
    public void RemoveModificador(float modificador)
    {
        if (modificador != 0)
            modificadores.Remove(modificador);

    }
}
