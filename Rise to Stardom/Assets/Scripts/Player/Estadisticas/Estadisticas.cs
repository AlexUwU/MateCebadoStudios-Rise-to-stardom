using UnityEngine;

[System.Serializable]
public class Estadisticas
{
    [SerializeField] private int valorBaseEstadistica;
    
    public int GetValor()
    {
        return valorBaseEstadistica;
    }
}
