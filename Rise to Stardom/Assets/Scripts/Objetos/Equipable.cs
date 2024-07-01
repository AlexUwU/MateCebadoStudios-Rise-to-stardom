using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipable nuevo", menuName = "Inventario/Equipable")]
public class Equipable : Objeto
{
    public int dmgModificador;
    public int velMovModificador;
    public float velAtqModificador;
    public int velProyModificador;
    public int tamProyModificador;
    public InstrumentAbilityBase instrumentAbility;

    public override void Usar()
    {
        base.Usar();
        instrumentAbility.Activate();
    }
}
