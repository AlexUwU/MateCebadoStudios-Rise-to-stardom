using UnityEngine;

public interface IEnemyState 
{
    void EnterState(Enemy enemy);
    void UpdateState(Enemy enemy);
    void ExitState(Enemy enemy);
    bool IsStateActive { get; }
}
