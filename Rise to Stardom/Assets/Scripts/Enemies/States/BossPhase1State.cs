using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase1State : BossPhaseState
{
    public BossPhase1State(Boss boss) : base(boss) { }

    protected override List<IEnemyAbility> GetAbilitiesForPhase()
    {
        return boss.Phase1Abilities.ConvertAll(a => (IEnemyAbility)a);
    }

    public override void UpdateState(Enemy enemy)
    {
        base.UpdateState(enemy);
        Debug.Log("Phase1");
    }
}
