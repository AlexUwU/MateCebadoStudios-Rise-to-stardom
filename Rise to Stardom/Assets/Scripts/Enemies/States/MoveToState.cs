using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToState : IEnemyState
{
    public bool IsStateActive { get; private set; }
    private Vector3 target;

    public MoveToState(Vector3 target)
    {
        this.target = target;
    }

    public void EnterState(Enemy enemy)
    {
        IsStateActive = true;
    }

    public void UpdateState(Enemy enemy)
    {
        Vector3 direction = (target - enemy.transform.position).normalized;
        enemy.Move(direction);
        if (Vector3.Distance(enemy.transform.position, target) < 0.5f)
        {
            
        }
    }

    public void ExitState(Enemy enemy)
    {
        IsStateActive = false;
    }
}
