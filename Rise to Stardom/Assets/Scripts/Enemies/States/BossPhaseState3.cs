using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase3State : BossPhaseState
{
    public BossPhase3State(Boss boss) : base(boss) { }

    protected override List<IEnemyAbility> GetAbilitiesForPhase()
    {
        return boss.Phase3Abilities.ConvertAll(a => (IEnemyAbility)a);
    }

    public override void UpdateState(Enemy enemy)
    {
        base.UpdateState(enemy);
        Vector3 direction = (GameObject.FindGameObjectWithTag("Player").transform.position - enemy.transform.position).normalized;
        enemy.MoveSpeed.BaseValue = 3f;
        enemy.Move(direction);
        //Debug.Log("Phase3");
    }
}
