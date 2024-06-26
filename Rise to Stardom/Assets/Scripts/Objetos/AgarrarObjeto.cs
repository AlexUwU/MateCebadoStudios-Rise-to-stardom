
using UnityEngine;

public class AgarrarObjeto : Interactuable
{
    public Objeto objeto;

    public override void OnTriggerEnter(Collider Player)
    {
        Interact();
    }
    public override void Interact()
    {
        Recoger();
    }

    void Recoger()
    {
        Debug.Log(objeto.name + " recogido");
        Inventario.instance.Add(objeto);
        Destroy(gameObject);
    }
}
