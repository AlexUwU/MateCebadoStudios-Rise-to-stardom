using UnityEngine;

public interface IInputHandler
{
    Vector3 GetInputMovement();
    bool IsShooting();
    bool IsHoldingFire();
    bool IsUsingAbilityWeapon();
    bool IsUsingConsumable();
    bool IsSwitchingConsumableLeft();
    bool IsSwitchingConsumableRight();
}