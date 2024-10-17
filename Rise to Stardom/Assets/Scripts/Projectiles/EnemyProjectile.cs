using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : BaseProjectile
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.CurrentHealth -= damage;
            }
            Destroy(gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            Enemy hitEnemy = other.GetComponent<Enemy>();
            if (hitEnemy != null && hitEnemy.enemyStateManager.currentStateName == "ConfusionState")
            {
                hitEnemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
