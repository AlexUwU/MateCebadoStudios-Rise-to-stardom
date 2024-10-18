using UnityEngine;
public class SemiFireMode : IFireModeHandler
{
    public void HandleFireMode(IInputHandler inputHandler, IShootHandler shootHandler, Transform pointer, WeaponInstrument weaponInstrument, float damage, float fireRate, float bulletSpeed)
    {
        if (inputHandler.IsShooting() && shootHandler.CanShoot())
        {
            Vector3 targetPosition = pointer.position;
            shootHandler.Shoot(targetPosition, weaponInstrument, damage, fireRate,bulletSpeed);
        }
    }
}
