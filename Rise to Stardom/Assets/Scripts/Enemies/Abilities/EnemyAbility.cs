using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbility : ScriptableObject, IEnemyAbility
{
    public abstract void Use(Enemy enemy);
    public abstract bool CanUse();
}
