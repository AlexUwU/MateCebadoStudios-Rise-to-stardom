using System;
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
    public delegate void OnEquipmentChanged(Equipable newEquipable, Equipable oldEquipable);
    public OnEquipmentChanged onEquipmentChangedCallback;

    //Se puede modificar para agregar un limite.
    public int limite = 1;
    public List<Equipable> instrumento = new List<Equipable>();
    public List<Equipable> objetos = new List<Equipable>();

    public void Add(Equipable objeto)
    {
        if (!objeto.isConsumableItem && !objeto.isInstrumentItem)
        {
            objetos.Add(objeto);
            onItemChangedCallback.Invoke();
            if (onEquipmentChangedCallback != null)
            {
                onEquipmentChangedCallback.Invoke(objeto, null);
            }
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
            if(onEquipmentChangedCallback != null)
            {
                onEquipmentChangedCallback.Invoke(objeto, null);
            }

        }
    }

    public void Remove(Equipable objeto) 
    { 
        objetos.Remove(objeto);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

        if (onEquipmentChangedCallback != null)
        {
            onEquipmentChangedCallback.Invoke(objeto, null);
        }
    }
    public void RemoverInstrumento ()
    {
        Equipable viejo = instrumento[0];
        instrumento.RemoveRange(0,1);


        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();

        if (onEquipmentChangedCallback != null)
        {
            onEquipmentChangedCallback.Invoke(null, viejo);
        }
    }
}
