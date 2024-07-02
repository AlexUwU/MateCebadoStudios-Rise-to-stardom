using UnityEngine;
public interface IEnemyAbility
{
    void Use(Enemy enemy);
    bool CanUse();
}

