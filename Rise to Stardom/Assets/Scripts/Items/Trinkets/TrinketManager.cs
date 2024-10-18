using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrinketManager : MonoBehaviour
{
    [SerializeField] private List<Trinket> trinkets = new List<Trinket>();

    public void AddTrinket(Trinket trinket)
    {
        trinkets.Add(trinket);
        trinket.ApplyEffect(gameObject);
    }

    public List<Trinket> GetTrinkets()
    {
        return trinkets;
    }
}
