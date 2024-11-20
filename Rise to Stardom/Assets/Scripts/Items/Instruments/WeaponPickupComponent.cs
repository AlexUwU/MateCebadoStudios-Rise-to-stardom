using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickupComponent : MonoBehaviour
{
    [SerializeField] private WeaponInstrument weapon;
    private bool playerInRange = false;

    [SerializeField] private PlayerController player;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Inventory inventory = FindObjectOfType<Inventory>();
            if (inventory != null)
            {
                inventory.GetWeaponManager().SwitchWeapon(weapon, transform.position);
                player = GameObject.Find("Player").GetComponent<PlayerController>();
                player.ChangeWeapon();
                Destroy(gameObject);
            }
        }
    }

    public WeaponInstrument GetWeapon()
    {
        return weapon;
    }
}
