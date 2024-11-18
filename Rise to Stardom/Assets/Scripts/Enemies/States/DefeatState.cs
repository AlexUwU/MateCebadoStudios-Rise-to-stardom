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

        DefeatPoints[] allDefeatPoints = GameObject.FindObjectsOfType<DefeatPoints>();
        DefeatPoints validDefeatPoints = null;

        foreach (var defeatPoints in allDefeatPoints)
        {
            if (defeatPoints.Points.Count > 0) 
            {
                validDefeatPoints = defeatPoints;
                break;
            }
        }

        if (validDefeatPoints != null)
        {
            nearestPoint = validDefeatPoints.GetNearestPoint(enemy.transform.position);
        }

        foreach (var defeatPoints in allDefeatPoints)
        {
            if (defeatPoints.Points.Count > 0)
            {
                validDefeatPoints = defeatPoints;
                break;
            }
        }

        if (validDefeatPoints != null)
        {
            nearestPoint = validDefeatPoints.GetNearestPoint(enemy.transform.position);
        }
    }

    public void UpdateState(Enemy enemy)
    {
        if (IsStateActive && nearestPoint != null)
        {
            Vector3 direction = (nearestPoint.position - enemy.transform.position).normalized;
            enemy.Move(direction);

            if(Vector3.Distance(enemy.transform.position, nearestPoint.position) < 0.1f)
            {
                ExitState(enemy);
            }
        }
    }

    public void ExitState(Enemy enemy)
    {
        IsStateActive = false;
    }
}
