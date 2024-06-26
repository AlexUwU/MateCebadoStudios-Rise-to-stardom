using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FanShootAbility", menuName = "EnemyAbility/FanShootAbility")]
public class FanShootAbility : EnemyAbility
{
    [SerializeField] private int numberOfBullets;
    [SerializeField] private float spreadAngle;
    [SerializeField] private float cooldown;
    [SerializeField] bool isEnabled;
    private bool isAvailable = true;
    private float timer;

    public FanShootAbility(int numberOfBullets, float spreadAngle)
    {
        this.numberOfBullets = numberOfBullets;
        this.spreadAngle = spreadAngle;
    }
    public override void Use(Enemy enemy)
    {
        if (CanUse())
        {
            float angleStep = spreadAngle / (numberOfBullets-1);
            float angle = -spreadAngle / 2;

            Transform firePoint = enemy.transform.Find("FirePoint");
            WeaponInstrument weaponInstrument = enemy.GetComponent<WeaponInstrument>();

            Boss boss = enemy as Boss;
            boss.Aim(enemy.objetivo.position);

            for (int i = 0; i < numberOfBullets; i++)
            {
                Vector3 directionToPlayer = (enemy.objetivo.position - firePoint.position).normalized;
                Vector3 direction = Quaternion.Euler(0, angle, 0) * directionToPlayer;

                GameObject bullet = GameObject.Instantiate(weaponInstrument.bulletNotePrefab, firePoint.position, Quaternion.identity);
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                if (bulletRigidbody != null)
                {
                    bulletRigidbody.velocity = direction * bullet.GetComponent<ProyectilBase>().speed;
                }

                ProyectilBase bulletComponent = bullet.GetComponent<ProyectilBase>();
                if (bulletComponent != null)
                {
                    bulletComponent.damage = enemy.Damage;
                }

                angle += angleStep;
            }

            timer = cooldown;
            isAvailable = false;
        }
    }

    public override bool CanUse()
    {
        if (!isAvailable && isEnabled)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                isAvailable = true;
            }
        }
        return isAvailable && isEnabled;
    }

    public void SetEnabled(bool enabled)
    {
        isEnabled = enabled;
        if (!enabled)
        {
            isAvailable = false;
        }
    }
}
