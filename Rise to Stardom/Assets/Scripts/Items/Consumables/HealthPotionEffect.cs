using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthPotionEffect", menuName = "Consumable Effects/Health Potion")]
public class HealthPotionEffect : ScriptableObject, IConsumableEffect
{
    [SerializeField] private float healAmount;

    public void ApplyEffect(GameObject user)
    {
        PlayerStats playerStats = user.GetComponent<PlayerStats>();
        if (playerStats != null)
        {
            playerStats.CurrentHealth += healAmount;
        }
    }
}
