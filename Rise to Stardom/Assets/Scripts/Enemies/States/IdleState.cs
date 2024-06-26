using UnityEngine;

public class IdleState : IEnemyState
{
    public bool IsStateActive { get; private set; }

    public void EnterState(Enemy enemy)
    {
        IsStateActive = true;
    }

    public void UpdateState(Enemy enemy)
    {
        enemy.Move(Vector3.zero);
    }

    public void ExitState(Enemy enemy)
    {
        IsStateActive = false;
    }
}