using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private PlayerController playerController;
    private PlayerStats playerStats;
    private Inventory inventory;
    public Transform playerTransform;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        playerStats = GetComponent<PlayerStats>();
        playerController = GetComponent<PlayerController>();
        inventory = GetComponent<Inventory>();
        playerTransform = transform;
    }
    public PlayerController PlayerController => playerController;
    public PlayerStats PlayerStats => playerStats;
    public Inventory Inventory => inventory;
}
