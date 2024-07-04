using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossPhaseState : IEnemyState
{
    protected Boss boss;
    public bool IsStateActive { get; private set; }

    public BossPhaseState(Boss boss)
    {
        this.boss = boss;
    }

    public virtual void EnterState(Enemy enemy)
    {
        IsStateActive = true;
        boss.SetAbilitiesForPhase(GetAbilitiesForPhase());
    }

    public virtual void UpdateState(Enemy enemy)
    {
        if (boss.playerDetectionHandler != null && boss.playerDetectionHandler.IsEnabled())
        {
            if (boss.playerDetectionHandler.IsPlayerInRange(enemy.transform.position))
            {
                boss.AimAndShoot(boss.objetivo.position);
                UseAbilities(boss.CurrentAbilities, enemy);
            }
        }
    }

    public virtual void ExitState(Enemy enemy)
    {
        IsStateActive = false;
    }

    protected abstract List<IEnemyAbility> GetAbilitiesForPhase();

    private void UseAbilities(List<IEnemyAbility> abilities, Enemy enemy)
    {
        foreach (var ability in abilities)
        {
            if (ability.CanUse())
            {
                ability.Use(enemy);
            }
        }
    }
}
