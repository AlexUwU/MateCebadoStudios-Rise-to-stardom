using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private Stat maxHealth;
    [SerializeField] private Stat currentHealth;
    [SerializeField] private Stat damage;
    [SerializeField] private Stat moveSpeed;
    [SerializeField] private Stat attackSpeed;
    [SerializeField] private Stat noteSpeed;
    [SerializeField] private Stat noteSize;

    [SerializeField] private int coins;


    public Stat MoveSpeedStat => moveSpeed;
    public float MoveSpeed => moveSpeed.Value;
    public float AttackSpeed => attackSpeed.Value;
    public float Damage => damage.Value;
    public float NoteSpeed => noteSpeed.Value;
    public float CurrentHealth
    {
        get => currentHealth.Value;
        set => currentHealth.BaseValue = Mathf.Clamp(value, 0, maxHealth.Value);
    }
    public float MaxHealth => maxHealth.Value;

    void Start(){
        coins = 0;
    }

    public void pickupCoin(){
        coins++;
    }

    public int coinCheck(){
        return coins;
    }

}
