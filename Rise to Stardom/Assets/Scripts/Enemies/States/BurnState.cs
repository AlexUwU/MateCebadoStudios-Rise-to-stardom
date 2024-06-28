using System.Collections;
using UnityEngine;

public class BurnState : IEnemyState
{
    private float damageOverTime;
    private float duration;
    public bool IsStateActive { get; private set; }

    public BurnState(float damageOverTimer, float duration)
    {
        this.damageOverTime = damageOverTimer;
        this.duration = duration;
    }
    public void EnterState(Enemy enemy)
    {
        IsStateActive = true;
        enemy.StartCoroutine(ApplyDamageOverTime(enemy));
    }

    public void UpdateState(Enemy enemy)
    {

    }

    public void ExitState(Enemy enemy) 
    {
        IsStateActive = false;
    }

    private IEnumerator ApplyDamageOverTime(Enemy enemy)
    {
        float timer = duration;
        while (timer >= 0 )
        {
            if (enemy == null)
            {
                yield break;
            }
            IHealthHandler healthHandler = enemy.GetComponent<HealthHandler>();
            if(healthHandler != null)
            {
                healthHandler.TakeDamage(damageOverTime);
            }
            timer -= 1f;
            yield return new WaitForSeconds(1f);
        }
        ExitState(enemy);
    }
}
