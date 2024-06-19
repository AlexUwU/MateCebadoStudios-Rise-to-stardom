using UnityEngine;

public class FanRangeEnemy : Enemy
{
    private WeaponInstrument weaponInstrument;
    private IMovementHandler movementHandler;
    private IShootHandler shootHandler;

    public override void Action()
    {
        return;
    }
    public override void Idle()
    {
        return;
    }
    public void Move(Vector2 direction)
    {
        movementHandler.Move(direction, Speed);
    }

    public void Shoot(Vector2 targetPosition) 
    {
        if (shootHandler.CanShoot(weaponInstrument))
        {
            shootHandler.Shoot(targetPosition, weaponInstrument,Damage);
        }
    }
}
