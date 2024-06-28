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

    public void Shoot(Vector3 targetPosition, WeaponInstrument weaponInstrument, int damage)
    {
        if(CanShoot(weaponInstrument)) 
        {
            //Modificado Bullet por Proyectil enemigo para que dispare otro tipo de proyectil.
            Vector3 firePointPosition = firePoint.position;
            Vector3 direction = (targetPosition - firePointPosition).normalized;

            GameObject bulletNote = GameObject.Instantiate(weaponInstrument.bulletNotePrefab, firePointPosition, Quaternion.identity);
            bulletNote.GetComponent<Rigidbody>().velocity = direction * weaponInstrument.bulletNotePrefab.GetComponent<ProyectilEnemigo>().speed;

            ProyectilEnemigo buletNoteComponent = bulletNote.GetComponent<ProyectilEnemigo>();
            buletNoteComponent.damage = damage;

            fireTimer = weaponInstrument.fireRate;
        }
    }

    public bool CanShoot(WeaponInstrument weaponInstrument)
    {
        if (fireTimer <= 0f)
        {
            return true;
        }
        fireTimer -= Time.deltaTime;
        return false;
    }
}
