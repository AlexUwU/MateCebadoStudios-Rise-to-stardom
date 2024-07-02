using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase3State : IEnemyState
{
    private Boss boss;

    public bool IsStateActive { get; private set; }
    public BossPhase3State(Boss boss)
    {
        this.boss = boss;
    }
    public void EnterState(Enemy enemy)
    {
        IsStateActive = true;
    }

    public void UpdateState(Enemy enemy)
    {
        Debug.Log("Phase3");
    }

    public void ExitState(Enemy enemy)
    {
        IsStateActive = false;
    }
}
