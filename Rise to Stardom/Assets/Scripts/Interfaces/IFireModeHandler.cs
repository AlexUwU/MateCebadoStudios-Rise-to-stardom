using UnityEngine;

public interface IFireModeHandler 
{
    void HandleFireMode(IInputHandler inputHandler, IShootHandler shootHandler, Transform pointer, WeaponInstrument weaponInstrument, int damage);
}
