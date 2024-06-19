using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IInputHandler inputHandler;
    private IMovementHandler movementHandler;
    private IShootHandler shootHandler;

    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform pointer;
    [SerializeField] private WeaponInstrument weaponInstrument;
    [SerializeField] private int damage;

    private void Start()
    {
        inputHandler = new PLayerInputHandler();
        movementHandler = new RigidbodyMovementHandler(GetComponent<Rigidbody>());
        shootHandler = new ShootHandler(firePoint);
    }

    private void Update()
    {
        Vector3 inputMovement = inputHandler.GetInputMovement();
        movementHandler.Move(inputMovement,moveSpeed);

        if (inputHandler.IsShooting())
        {
            Vector3 targetPosition = pointer.position;
            if (shootHandler.CanShoot(weaponInstrument))
            {
                shootHandler.Shoot(targetPosition, weaponInstrument,damage);
            }
        }
        else
        {
            shootHandler.CanShoot(weaponInstrument);
        }
    }

}
