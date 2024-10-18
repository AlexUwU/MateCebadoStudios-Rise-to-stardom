using UnityEngine;
public class AutoFireMode : IFireModeHandler
{
    public void HandleFireMode(IInputHandler inputHandler, IShootHandler shootHandler, Transform pointer, WeaponInstrument weaponInstrument, float damage, float fireRate,float bulletSpeed)
    {
        if (inputHandler.IsHoldingFire() && shootHandler.CanShoot())
        {
            Vector3 targetPosition = pointer.position;
            shootHandler.Shoot(targetPosition, weaponInstrument, damage,fireRate,bulletSpeed);
        }
    }
}
