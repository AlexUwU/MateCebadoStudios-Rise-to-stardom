using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    private IEnemyState currentState;
    private string currentStateName;
    private List<IEnemyState> secondaryStates = new List<IEnemyState>();
    public void SetState(IEnemyState newState, Enemy enemy)
    {
        if (currentState != null)
        {
            currentState.ExitState(enemy);
        }
        currentState = newState;
        currentStateName = newState.GetType().Name;
        currentState.EnterState(enemy);
        Debug.Log($"Current state: {currentStateName}");
    }

    public void AddSecondaryState(IEnemyState newState,Enemy enemy)
    {
        newState.EnterState(enemy);
        secondaryStates.Add(newState);
    }

    public void Update()
    {
        if (currentState != null && currentState.IsStateActive)
        {
            currentState.UpdateState(GetComponent<Enemy>());
        }
        foreach (var state in secondaryStates.ToArray())
        {
            if (state.IsStateActive)
            {
                state.UpdateState(GetComponent<Enemy>());
            }
            else
            {
                secondaryStates.Remove(state);
            }
        }
    }
}
