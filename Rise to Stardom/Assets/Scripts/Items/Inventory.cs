using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    private WeaponManager weaponManager;
    private ConsumableManager consumableManager;
    private TrinketManager trinketManager;

    public void Start()
    {
        weaponManager = GetComponent<WeaponManager>();
        consumableManager = GetComponent<ConsumableManager>();
        trinketManager = GetComponent<TrinketManager>();
    }
    public WeaponManager GetWeaponManager()
    {
        return weaponManager;
    }
    public ConsumableManager GetConsumableManager()
    {
        return consumableManager;
    }
    public TrinketManager GetTrinketManager()
    {
        return trinketManager;
    }
}
