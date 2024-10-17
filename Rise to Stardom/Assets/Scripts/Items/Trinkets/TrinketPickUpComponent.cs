using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrinketPickUpComponent : MonoBehaviour
{
    [SerializeField] private Trinket trinket;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TrinketManager trinketManager = other.GetComponent<TrinketManager>();
            if (trinketManager != null)
            {
                trinketManager.AddTrinket(trinket);
                Destroy(gameObject);
            }
        }
    }
    public Trinket GetTrinket()
    {
        return trinket;
    }
}
