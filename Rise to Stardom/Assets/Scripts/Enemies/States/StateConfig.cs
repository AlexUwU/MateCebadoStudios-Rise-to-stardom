using UnityEngine;

public abstract class StateConfig : ScriptableObject
{
    public abstract IEnemyState CreateState();
}
