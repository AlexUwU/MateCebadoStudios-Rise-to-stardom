using UnityEngine;
public interface IShootHandler
{
    void Shoot(Vector3 targetPosition, WeaponInstrument weaponInstrument,int damage);
    bool CanShoot(WeaponInstrument weaponInstrument);
}