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
    private Coroutine cooldownCoroutine;

    public FanShootAbility(int numberOfBullets, float spreadAngle)
    {
        this.numberOfBullets = numberOfBullets;
        this.spreadAngle = spreadAngle;
    }
    public override void Use(Enemy enemy)
    {
        if (CanUse())
        {
            Boss boss = enemy as Boss;
            if (boss == null || boss.weaponInstrument == null) return;

            Transform firePoint = boss.firepoint;
            if (firePoint == null) return;

            boss.Aim(Player.Instance.transform.position);
            
            float angleStep = spreadAngle / (numberOfBullets-1);
            float angle = -spreadAngle / 2;

            for (int i = 0; i < numberOfBullets; i++)
            {
                Vector3 directionToPlayer = (GameObject.FindGameObjectWithTag("Player").transform.position - firePoint.position).normalized;
                Vector3 direction = Quaternion.Euler(0, angle, 0) * directionToPlayer;

                GameObject bullet = GameObject.Instantiate(boss.weaponInstrument.bulletNotePrefab, firePoint.position, Quaternion.identity);
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                if (bulletRigidbody != null)
                {
                    bulletRigidbody.velocity = direction * boss.BulletSpeed.Value;
                }

                ProyectilBase bulletComponent = bullet.GetComponent<ProyectilBase>();
                if (bulletComponent != null)
                {
                    bulletComponent.damage = enemy.Damage.Value;
                }

                angle += angleStep;
            }

            cooldownCoroutine = enemy.StartCoroutine(CooldownCoroutine());
        }
    }
    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(cooldown);
        cooldownCoroutine = null;
    }
    public override bool CanUse()
    {
        return cooldownCoroutine == null && isEnabled;
    }
}
