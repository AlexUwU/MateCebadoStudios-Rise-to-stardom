using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewConsumable", menuName = "Inventory/Consumable")]
public class Consumable : ScriptableObject, IItem
{
    [SerializeField] private string itemName;
    [SerializeField] private int maxStackSize;
    [SerializeField] private ScriptableObject consumableEffect;
    private int quantity;

    public string ItemName => itemName;
    public int MaxStackSize => maxStackSize;
    public int Quantity => quantity;

    public void Initialize(int InitialQuantity)
    {
        quantity = Mathf.Clamp(InitialQuantity,0,maxStackSize);
    }

    public void Use(GameObject user)
    {
        if (quantity > 0 && consumableEffect is IConsumableEffect effect)
        {
            effect.ApplyEffect(user);
            quantity--;
        }
    }

    public void Use() { }

    public bool IsEmpty()
    {
        return quantity <= 0;
    }

    public void AddQuantiy(int amount)
    {
        quantity = Mathf.Clamp(quantity+amount,0,maxStackSize);
    }
}
