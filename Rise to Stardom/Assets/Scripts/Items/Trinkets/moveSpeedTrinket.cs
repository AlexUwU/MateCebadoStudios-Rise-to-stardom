using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveSpeedTrinketEffect", menuName = "Trinket Effects/SpeedTrinketEffect")]
public class moveSpeedTrinket : ScriptableObject, ITrinketEffect
{
    [SerializeField] private float speedAmount;

    public void ApplyEffect(GameObject user)
    {
        PlayerStats playerStats = user.GetComponent<PlayerStats>();

        if (playerStats != null)
        {
            playerStats.MoveSpeedStat.AddModifier(speedAmount);
        }
    }
}
