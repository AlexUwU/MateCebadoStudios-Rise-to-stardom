using UnityEngine;

public class ReturnInitialPositionState : IEnemyState
{
    public bool IsStateActive { get; private set; }

    public void EnterState(Enemy enemy)
    {
        IsStateActive = true;
    }

    public void UpdateState(Enemy enemy)
    {
        Vector3 direction = (enemy.InitialPosition - enemy.transform.position).normalized;
        
        if (Vector3.Distance(enemy.transform.position, enemy.InitialPosition) < 0.1f)
        {
            enemy.SetState(new IdleState());
            IsStateActive = false;
        }
        else
        {
            enemy.Move(direction);
        }
    }

    public void ExitState(Enemy enemy)
    {
        IsStateActive = false;
    }
}
