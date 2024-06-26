using UnityEngine;

public class FanRangeAttackBehaviour : IAttackBehaviour
{
    public void Attack(Enemy enemy, Transform target)
    {
        FanRangeEnemy fanRangeEnemy = enemy as FanRangeEnemy;
        if (fanRangeEnemy != null)
        {
            fanRangeEnemy.AimAndShoot(target.position);
        }
    }
}