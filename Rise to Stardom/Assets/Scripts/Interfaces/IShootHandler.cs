using UnityEngine;
public interface IShootHandler
{
    void Shoot(Vector3 targetPosition, WeaponInstrument weaponInstrument,float damage,float attackSpeed, float bulletSpeed);
    bool CanShoot();

    void Update();
}