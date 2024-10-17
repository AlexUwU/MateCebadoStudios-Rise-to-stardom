using UnityEngine;
public class ShootHandler : IShootHandler
{
    private Transform firePoint;
    private float fireTimer;

    public ShootHandler(Transform firePoint)
    {
        this.firePoint = firePoint;
        this.fireTimer = 0f;
    }

    public void Shoot(Vector3 targetPosition, WeaponInstrument weaponInstrument, float damage, float attackSpeed,float bulletSpeed)
    {
        float fireInterval = 1f/ attackSpeed;

        if(CanShoot()) 
        {
            weaponInstrument.Use(firePoint, targetPosition, damage, bulletSpeed);
            fireTimer = fireInterval;
        }
    }

    public bool CanShoot()
    {
        if (fireTimer <= 0f)
        {
            return true;
        }
        return false;
    }

    public void Update() // Nueva función para actualizar el temporizador
    {
        if (fireTimer > 0f)
        {
            fireTimer -= Time.deltaTime; // Decrementa el temporizador en cada frame
        }
    }
}
