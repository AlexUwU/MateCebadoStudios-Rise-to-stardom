using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase2State : IEnemyState
{
    private Boss boss;

    public bool IsStateActive { get; private set; }
    public BossPhase2State(Boss boss)
    {
        this.boss = boss;
    }
    public void EnterState(Enemy enemy)
    {
        IsStateActive = true;
    }

    public void UpdateState(Enemy enemy)
    {
        Debug.Log("Phase2");
    }

    public void ExitState(Enemy enemy)
    {
        IsStateActive = false;
    }
}
