using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumablePickupComponent : MonoBehaviour
{
    [SerializeField] private Consumable consumable;
    [SerializeField] private int quantity;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ConsumableManager consumableManager = other.GetComponent<ConsumableManager>();
            if (consumableManager != null)
            {
                consumableManager.AddConsumable(consumable, quantity);
                Destroy(gameObject);
            }
        }
    }

    public Consumable GetConsumable()
    {
        return consumable;
    }
}
