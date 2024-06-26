using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Estadisticas
{
    [SerializeField] private int valorBaseEstadistica;
    private List<int> modificadores = new List<int>();
    public int GetValor()
    {
        int valorFinal = valorBaseEstadistica;
        modificadores.ForEach(x => valorFinal += x);

        return valorFinal;
    }
    public void AddModificador(int modificador)
    {
        if(modificador != 0)
            modificadores.Add(modificador);
    }
    public void RemoveModificador(int modificador)
    {
        if (modificador != 0)
            modificadores.Remove(modificador);

    }
}
