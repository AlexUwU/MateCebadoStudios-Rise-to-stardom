using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableManager : MonoBehaviour
{
    [SerializeField] private List<Consumable> consumables = new List<Consumable>(4);
    [SerializeField] Consumable CurrentConsumable;
    private int currentConsumableIndex = 0;

    public void Update()
    {
        CurrentConsumable = GetCurrentConsumable();
    }
    public void AddConsumable(Consumable consumable,int amount)
    {
        if (consumables.Count < 4)
        {
            consumable.Initialize(amount);
            consumables.Add(consumable);
        }
    }

    public void UseCurrentConsumable(GameObject user)
    {
        if(consumables.Count > 0 && consumables[currentConsumableIndex] != null)
        {
            consumables[currentConsumableIndex].Use(user);
            if (consumables[currentConsumableIndex].IsEmpty())
            {
                consumables.RemoveAt(currentConsumableIndex);
                if (currentConsumableIndex >= consumables.Count)
                {
                    currentConsumableIndex = Mathf.Max(consumables.Count - 1, 0);
                }
            }
        }
    }

    public void SwitchConsumable(bool forward)
    {
        if (consumables.Count > 0)
        {
            currentConsumableIndex = (currentConsumableIndex + (forward ? 1 : -1) + consumables.Count) % consumables.Count;
        }
    }
    public Consumable GetCurrentConsumable()
    {
        return consumables.Count > 0 ? consumables[currentConsumableIndex] : null;
    }
}
