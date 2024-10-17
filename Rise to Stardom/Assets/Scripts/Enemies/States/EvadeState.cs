using UnityEngine;

public class EvadeState : IEnemyState
{
    public bool IsStateActive { get; private set; }

    public void EnterState(Enemy enemy) 
    {
        IsStateActive = true;
    }

    public void UpdateState(Enemy enemy)
    {
        Vector3 playerPosition = Player.Instance.playerTransform.position;
        Vector3 direction = (enemy.transform.position - playerPosition).normalized;
        enemy.Move(direction);

        FanRangeEnemy fanRangeEnemy = enemy as FanRangeEnemy;
        if (fanRangeEnemy != null)
        {
            fanRangeEnemy.AimAndShoot(playerPosition);
        }
    }

    public void ExitState(Enemy enemy)
    {
        IsStateActive = false;
    }
}
