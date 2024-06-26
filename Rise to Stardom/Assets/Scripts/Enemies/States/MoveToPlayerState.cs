using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayerState : IEnemyState
{
    public bool IsStateActive { get; private set; }

    public void EnterState(Enemy enemy)
    {
        IsStateActive = true;
    }

    public void UpdateState(Enemy enemy)
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 direction = (playerPosition - enemy.transform.position).normalized;
        enemy.Move(direction);
    }

    public void ExitState(Enemy enemy)
    {
        IsStateActive = false;
    }
}
