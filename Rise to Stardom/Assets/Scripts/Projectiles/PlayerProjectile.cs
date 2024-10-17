using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : BaseProjectile
{
    public override void OnTriggerEnter(Collider enemy)
    {
        if (enemy != null)
        {
            if (enemy.tag == "Enemy" || (enemy.tag == "Player" && GetOwner().CompareTag("Enemy")))
            {
                IDamageable damageable = enemy.gameObject.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.TakeDamage(damage);
                }
                Destroy(gameObject);
            }
        }
    }
}