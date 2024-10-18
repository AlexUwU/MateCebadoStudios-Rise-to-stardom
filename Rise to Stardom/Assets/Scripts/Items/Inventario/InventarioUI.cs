using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioUI : MonoBehaviour
{
    public Transform objetosPadre, intrumento;
    Inventario inventario;
    InventarioEspacio[] espaciosObjetos, espacioIntrumento;
    
    void Start()
    {
        inventario = Inventario.instance;
        inventario.onItemChangedCallback += ActualizarUI;
        espaciosObjetos = objetosPadre.GetComponentsInChildren<InventarioEspacio>();
        espacioIntrumento = intrumento.GetComponentsInChildren<InventarioEspacio>();
    }

    void Update()
    {
    }

    public void tocarInstrumento()
    {
        espacioIntrumento[0].UsarObjeto();
    }
    void ActualizarUI()
    {
        for(int i=0; i < espaciosObjetos.Length; i++)
        {
            if(i < inventario.objetos.Count)
            {
                espaciosObjetos[i].AddObjeto(inventario.objetos[i]);
            }
            else
            {
                espaciosObjetos[i].ClearSlot();
            }
        }

        for (int i = 0; i < espacioIntrumento.Length; i++)
        {
            if (i < inventario.instrumento.Count)
            {
                espacioIntrumento[i].AddObjeto(inventario.instrumento[i]);
            }
            else
            {
                espacioIntrumento[i].ClearSlot();
            }
        }
    }

}
