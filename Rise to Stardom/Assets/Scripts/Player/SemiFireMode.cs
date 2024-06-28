using UnityEngine;
public class SemiFireMode : IFireModeHandler
{
    public void HandleFireMode(IInputHandler inputHandler, IShootHandler shootHandler, Transform pointer, WeaponInstrument weaponInstrument, int damage)
    {
        if (inputHandler.IsShooting() && shootHandler.CanShoot())
        {
            Vector3 targetPosition = pointer.position;
            shootHandler.Shoot(targetPosition, weaponInstrument, damage);
        }
        else
        {
            shootHandler.CanShoot();
        }
    }
}
