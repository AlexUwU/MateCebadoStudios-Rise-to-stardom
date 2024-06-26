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

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

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
            if (instrumento.Count >= limite)
            {
                Debug.Log("Cambio de instrumento");
                RemoverInstrumento();
            }
            instrumento.Add(objeto);

            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
    }

    public void Remove(Objeto objeto) 
    { 
        objetos.Remove(objeto);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
    public void RemoverInstrumento ()
    {
        instrumento.RemoveRange(0,1);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
