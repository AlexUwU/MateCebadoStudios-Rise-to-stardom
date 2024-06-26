using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagonistaEstadisticas : PersonajeEstadisticas
{
    void Start()
    {
        Inventario.instance.onEquipmentChangedCallback += onEquipmentChanged;
    }
    void onEquipmentChanged(Equipable newEquipable, Equipable oldEquipable)
    {
        if (newEquipable != null)
        {
            dmg.AddModificador(newEquipable.dmgModificador);
            velMov.AddModificador(newEquipable.velMovModificador);
            velAtq.AddModificador(newEquipable.velAtqModificador);
            velProy.AddModificador(newEquipable.velProyModificador);
            tamProy.AddModificador(newEquipable.tamProyModificador);
        }

        if (oldEquipable != null)
        {
            dmg.RemoveModificador(oldEquipable.dmgModificador);
            velMov.RemoveModificador(oldEquipable.velMovModificador);
            velAtq.RemoveModificador(oldEquipable.velAtqModificador);
            velProy.RemoveModificador(oldEquipable.velProyModificador);
            tamProy.RemoveModificador(oldEquipable.tamProyModificador);
        }
    }
}
