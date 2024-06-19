using UnityEngine;

public interface IInputHandler
{
    Vector3 GetInputMovement();
    bool IsShooting();
}