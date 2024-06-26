using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    #region Singleton Inventario
    public static Inventario instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Mas de una instancia de inventario a sido encontrada!!!!!");
            return;
        }
        instance = this;
    }
    #endregion
    //Se puede modificar para agregar un limite.
    public int limite = 1;
    public List<Objeto> instrumento = new List<Objeto>();
    public List<Objeto> objetos = new List<Objeto>();

    public void Add(Objeto objeto)
    {
        if (!objeto.isConsumableItem && !objeto.isInstrumentItem)
        {
            objetos.Add(objeto);
        }
        if (objeto.isInstrumentItem && !objeto.isConsumableItem)
        {
            instrumento.Add(objeto);
        }
    }

    public void Remove(Objeto objeto) 
    { 
        objetos.Remove(objeto); 
    }
    public void RemoverInstrumento (Objeto objeto)
    {
        instrumento.Remove(objeto);
    }
}
