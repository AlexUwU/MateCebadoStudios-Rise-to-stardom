using UnityEngine;
using UnityEngine.UI;

public class InventarioEspacio : MonoBehaviour
{
    Equipable objeto;
    public Image icono;

    public void AddObjeto(Equipable nuevoObjeto)
    {
        objeto = nuevoObjeto;
        icono.sprite = objeto.icono;
        icono.enabled = true;
    }

    public void ClearSlot()
    {
        objeto = null;
        icono.sprite=null;
        icono.enabled = false;
    }

    public void UsarObjeto()
    {
        if(objeto != null)
        {
            objeto.Usar();
        }
    }
}
