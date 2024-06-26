using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararJugador : MonoBehaviour
{
    private IInputHandler inputHandler;
    private IShootHandler shootHandler;
    private IFirepointHandler firepointHandler;

    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform pointer;
    [SerializeField] private WeaponInstrument weaponInstrument;
    [SerializeField] private int damage;
    [SerializeField] private float firePointDistance;
    private void Start()
    {
        inputHandler = new PLayerInputHandler();
        shootHandler = new ShootHandler(firePoint);
        firepointHandler = new FirepointHandler(firePoint, transform, firePointDistance);
    }

    private void Update()
    {
        Vector3 pointerTargetPosition = pointer.position;
        firepointHandler.Aim(pointerTargetPosition);

        if (inputHandler.IsShooting())
        {
            Vector3 targetPosition = pointer.position;
            if (shootHandler.CanShoot(weaponInstrument))
            {
                shootHandler.Shoot(targetPosition, weaponInstrument, damage);
            }
        }
        else
        {
            shootHandler.CanShoot(weaponInstrument);
        }
    }
}
