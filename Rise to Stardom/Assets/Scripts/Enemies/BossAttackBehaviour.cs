using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackBehaviour : IAttackBehaviour
{
    private Boss boss;
    private List<IEnemyAbility> currentPhaseAbilities;
    public BossAttackBehaviour(Boss boss)
    {
        this.boss = boss;
        currentPhaseAbilities = new List<IEnemyAbility>();
    }
    public void Attack(Enemy enemy, Transform target)
    {
        boss.AimAndShoot(target.position);
        Debug.Log("xd");
        UseAbilities(currentPhaseAbilities, enemy);
    }
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
    public void SetAbilitiesForPhase(List<IEnemyAbility> abilities)
    {
        currentPhaseAbilities = abilities;
    }
}
