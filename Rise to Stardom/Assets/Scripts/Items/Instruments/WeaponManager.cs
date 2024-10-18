using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private WeaponInstrument equippedWeapon;
    private Inventory inventory;

    public void Start()
    {
        inventory = GetComponent<Inventory>();
        if (equippedWeapon != null)
        {
            EquipWeapon(equippedWeapon);
        }
    }

    public void EquipWeapon(WeaponInstrument weapon)
    {
        if (weapon != null)
        {
            equippedWeapon = weapon;
        }
    }

    public void UnequipWeapon()
    {
        equippedWeapon = null;
    }

    public void UseWeapon()
    {
        equippedWeapon?.Use();
    }

    public void SwitchWeapon(WeaponInstrument newWeapon, Vector3 dropPosition)
    {
        if (equippedWeapon != null)
        {
            equippedWeapon.Drop(dropPosition);
        }

        EquipWeapon(newWeapon);
    }

    public WeaponInstrument GetEquippedWeapon()
    {
        return equippedWeapon;
    }
}
