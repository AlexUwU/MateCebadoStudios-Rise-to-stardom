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
            Vector3 firePointPosition = firePoint.position;
            Vector3 direction = (targetPosition - firePointPosition).normalized;

            GameObject bulletNote = GameObject.Instantiate(weaponInstrument.bulletNotePrefab, firePointPosition, Quaternion.identity);
            bulletNote.GetComponent<Rigidbody>().velocity = direction * weaponInstrument.bulletNotePrefab.GetComponent<BulletNote>().speed;

            BulletNote buletNoteComponent = bulletNote.GetComponent<BulletNote>();
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
