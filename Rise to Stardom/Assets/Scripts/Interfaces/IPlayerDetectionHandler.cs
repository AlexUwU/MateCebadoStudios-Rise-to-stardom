using UnityEngine;

public interface IPlayerDetectionHandler
{
    bool IsPlayerInRange(Vector3 position);
    void SetEnabled(bool enabled);
    bool IsEnabled();
}