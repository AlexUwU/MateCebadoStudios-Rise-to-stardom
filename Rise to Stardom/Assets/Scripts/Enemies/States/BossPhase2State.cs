using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase2State : BossPhaseState
{
    public BossPhase2State(Boss boss) : base(boss) { }

    protected override List<IEnemyAbility> GetAbilitiesForPhase()
    {
        return boss.Phase2Abilities.ConvertAll(a => (IEnemyAbility)a);
    }

    public override void UpdateState(Enemy enemy)
    {
        base.UpdateState(enemy);
        RotateAroundPlayer(enemy);
        //Debug.Log("Phase2");
    }
    private void RotateAroundPlayer(Enemy enemy)
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        float rotationSpeed = 2f;
        float orbitRadius = 5f; 

        Vector3 offset = new Vector3(Mathf.Sin(Time.time * rotationSpeed), 0, Mathf.Cos(Time.time * rotationSpeed)) * orbitRadius;
        Vector3 targetPosition = player.position + offset;

        Vector3 direction = (targetPosition - enemy.transform.position).normalized;
        enemy.MoveSpeed.BaseValue = 2f; 
        enemy.Move(direction);

        enemy.transform.LookAt(player);
    }
}
