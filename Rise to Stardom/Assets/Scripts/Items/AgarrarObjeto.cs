
using UnityEngine;

public class AgarrarObjeto : Interactuable
{
    public Equipable objeto;

    public override void OnTriggerEnter(Collider Player)
    {
        if(Player.tag == "Player")
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
