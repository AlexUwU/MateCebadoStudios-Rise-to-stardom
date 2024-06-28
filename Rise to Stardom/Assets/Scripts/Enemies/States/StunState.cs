using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunState : IEnemyState
{
    private float duration;
    private float timer;
    public bool IsStateActive {  get; private set; }

    public StunState(float duration)
    {
        this.duration = duration;
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
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ExitState(enemy);
        }
    }

    public void ExitState(Enemy enemy)
    {
        IsStateActive = false;
        enemy.playerDetectionHandler.SetEnabled(true);
    }
}
