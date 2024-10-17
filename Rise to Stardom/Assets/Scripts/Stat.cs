using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class Stat 
{
    [SerializeField] private float baseValue;
    [SerializeField] private List<float> modifiers = new List<float>();

    public float BaseValue
    {
        get => baseValue;
        set => baseValue = value;
    }

    public float Value => GetValue();
    public float GetValue()
    {
        float finalValue = baseValue + modifiers.Sum();
        return Mathf.Max(finalValue, 0f);
    }
    public void AddModifier(float modifier)
    {
        if (modifier!=0) modifiers.Add(modifier);
    }
    public void RemoveModifier(float modifier) {
        if (modifier!=0) modifiers.Remove(modifier);
    }
}
