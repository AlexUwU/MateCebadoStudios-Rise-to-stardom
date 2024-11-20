using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnEnemyAbility", menuName = "EnemyAbility/SpawnEnemyAbility")]
public class SpawnEnemyAbility : EnemyAbility
{
    [SerializeField] private GameObject enemyPrefab; 
    [SerializeField] private int numberOfEnemies;    
    [SerializeField] private float spawnRadius;      
    [SerializeField] private float spawnInterval;    
    [SerializeField] private float cooldown;
    [SerializeField] bool isEnabled;
    private Coroutine cooldownCoroutine;
    public float SpawnRadius { get { return spawnRadius; } }

    public override void Use(Enemy enemy)
    {
        if (CanUse())
        {   
            Boss boss = enemy as Boss;
            boss.anim.SetTrigger("SummonEnemy");
            enemy.StartCoroutine(SpawnEnemies(enemy));
            cooldownCoroutine = enemy.StartCoroutine(CooldownCoroutine());
        }
    }

    private IEnumerator SpawnEnemies(Enemy enemy)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 spawnPosition = enemy.transform.position + (Random.insideUnitSphere * spawnRadius);
            spawnPosition.y = enemy.transform.position.y;
            GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
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