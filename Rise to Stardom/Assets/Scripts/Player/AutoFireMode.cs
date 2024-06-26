using UnityEngine;
public class AutoFireMode : IFireModeHandler
{
    public void HandleFireMode(IInputHandler inputHandler, IShootHandler shootHandler, Transform pointer, WeaponInstrument weaponInstrument, int damage)
    {
        if (inputHandler.IsHoldingFire() && shootHandler.CanShoot())
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
