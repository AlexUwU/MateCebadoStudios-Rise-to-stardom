using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IInputHandler inputHandler;
    private IMovementHandler movementHandler;
    private IShootHandler shootHandler;
    private IFirepointHandler firepointHandler;
    private Dictionary<FireMode, IFireModeHandler> fireModes;

    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform pointer;
    [SerializeField] private WeaponInstrument weaponInstrument;
    [SerializeField] private int damage;
    [SerializeField] private float firePointDistance;

    private void Start()
    {
        inputHandler = new PLayerInputHandler();
        movementHandler = new RigidbodyMovementHandler(GetComponent<Rigidbody>());
        shootHandler = new ShootHandler(firePoint);
        firepointHandler = new FirepointHandler(firePoint, transform, firePointDistance);

        fireModes = new Dictionary<FireMode, IFireModeHandler>
        {
            { FireMode.Auto, new AutoFireMode()},
            { FireMode.Semi, new SemiFireMode() }
        };
    }

    private void Update()
    {
        Vector3 inputMovement = inputHandler.GetInputMovement();
        movementHandler.Move(inputMovement,moveSpeed);

        Vector3 pointerTargetPosition = pointer.position;
        firepointHandler.Aim(pointerTargetPosition);

        IFireModeHandler fireModeHandler = fireModes[weaponInstrument.fireMode];
        fireModeHandler.HandleFireMode(inputHandler, shootHandler, pointer, weaponInstrument, damage);

        if (Input.GetKeyDown(KeyCode.Q) && weaponInstrument.instrumentAbiltity != null)
        {
            weaponInstrument.instrumentAbiltity.Activate();
        }
    }
}
