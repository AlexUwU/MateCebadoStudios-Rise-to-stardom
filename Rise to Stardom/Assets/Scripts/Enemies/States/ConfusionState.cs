using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfusionState : IEnemyState
{
    private float duration;
    private float timer;
    private Enemy owner;
    public bool IsStateActive { get; private set; }

    public ConfusionState(float duration, Enemy owner)
    {
        this.duration = duration;
        this.owner = owner;
    }

    public void EnterState(Enemy enemy)
    {
        IsStateActive = true;
        timer = duration;
        enemy.Move(Vector3.zero);
        enemy.playerDetectionHandler.SetEnabled(false);
    }
    public void UpdateState(Enemy enemy)
    {
        if(IsStateActive)
        {
            AttackOtherEnemies(enemy);
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                ExitState(enemy);
            }
        }
    }
    public void ExitState(Enemy enemy)
    {
        IsStateActive = false;
        enemy.playerDetectionHandler.SetEnabled(true);
    }

    public void AttackOtherEnemies(Enemy enemy)
    {
        Enemy nearEnemy = FindNearestEnemy(enemy);
        if(nearEnemy != null)
        {
            enemy.AttackBehaviour.Attack(enemy, nearEnemy.transform);
        }
    }

    public Enemy FindNearestEnemy(Enemy enemy)
    {
        Enemy nearestEnemy = null;
        float distance = float.MaxValue;

        foreach (Enemy enemyTarget in GameObject.FindObjectsOfType<Enemy>()) 
        {
            if (enemyTarget == enemy) continue;
            float distanceEnemyTarget = Vector3.Distance(enemy.transform.position, enemyTarget.transform.position);
            if (distanceEnemyTarget < distance)
            {
                distance = distanceEnemyTarget;
                nearestEnemy = enemyTarget;
            }
        }

        return nearestEnemy;
    }
}
