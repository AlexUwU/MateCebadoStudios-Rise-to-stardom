using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CircleShootAbility", menuName = "EnemyAbility/CircleShootAbility")]
public class CircleShootAbility : EnemyAbility
{
    [SerializeField] private int numberOfBullets;
    [SerializeField] private float cooldown;
    [SerializeField] private bool isEnabled;
    private Coroutine cooldownCoroutine;

    public CircleShootAbility(int numberOfBullets)
    {
        this.numberOfBullets = numberOfBullets;
    }

    public override void Use(Enemy enemy)
    {
        if (CanUse())
        {
            Boss boss = enemy as Boss;
            if (boss == null || boss.weaponInstrument == null) return;

            Transform firePoint = boss.firepoint;
            if (firePoint == null) return;

            float angleStep = 360f / numberOfBullets;
            float angle = 0f;
            boss.anim.SetTrigger("AreaAttack");

            for (int i = 0; i < numberOfBullets; i++)
            {
                Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.forward;

                GameObject bullet = GameObject.Instantiate(boss.weaponInstrument.bulletNotePrefab, boss.transform.position, Quaternion.identity);
                Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
                if (bulletRigidbody != null)
                {
                    bulletRigidbody.velocity = direction * boss.BulletSpeed.Value;
                }

                BaseProjectile bulletComponent = bullet.GetComponent<BaseProjectile>();
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