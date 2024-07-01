using UnityEngine;
[CreateAssetMenu(fileName ="InstrumentAbility",menuName ="Abilities/InstrumentAbility")]
public abstract class InstrumentAbilityBase : ScriptableObject
{
    public abstract void Activate();
}