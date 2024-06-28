using UnityEngine;

public class AttackState : IEnemyState
{
    public bool IsStateActive { get; private set; }

    private Transform target;
    public AttackState (Transform target)
    {
        this.target = target;
    }

    public void EnterState(Enemy enemy)
    {
        IsStateActive = true;
    }

    public void UpdateState(Enemy enemy)
    {
        enemy.AttackBehaviour.Attack(enemy, target);
    }
    public void ExitState(Enemy enemy)
    {
        IsStateActive = false;
    }
}
