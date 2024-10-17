using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTrinket", menuName = "Inventory/Trinket")]
public class Trinket : ScriptableObject, IItem
{
    [SerializeField] private string itemName;
    [SerializeField] private string description;
    [SerializeField] private ScriptableObject trinketEffect;
    public string ItemName => itemName;
    public string Description => description;
    public void ApplyEffect(GameObject user)
    {
        if (trinketEffect is ITrinketEffect effect)
        {
            effect.ApplyEffect(user);
        }
    }
    public void Use() { }
}
