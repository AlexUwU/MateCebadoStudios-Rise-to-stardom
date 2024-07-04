using UnityEngine;

public class DefeatState : IEnemyState
{
    public bool IsStateActive { get; private set; }
    private Transform nearestPoint;

    public void EnterState(Enemy enemy) 
    {
        IsStateActive = true;
        enemy.playerDetectionHandler.SetEnabled(false);
        enemy.Move(Vector3.zero);
        //DefeatPoints defeatPoints = GameObject.FindObjectOfType<DefeatPoints>();
        //nearestPoint = defeatPoints.GetNearestPoint(enemy.transform.position);

    }

    public void UpdateState(Enemy enemy)
    {
        //if (IsStateActive && nearestPoint != null)
        //{
        //    Vector3 direction = (nearestPoint.position - enemy.transform.position).normalized;
        //    enemy.Move(direction);

        //    if(Vector3.Distance(enemy.transform.position, nearestPoint.position) < 0.1f)
        //    {
        //        ExitState(enemy);
        //    }
        //}
    }

    public void ExitState(Enemy enemy)
    {
        IsStateActive = false;
    }
}
