using UnityEngine;

public class FanRangeEnemy : Enemy
{
    private WeaponInstrument weaponInstrument;
    private IMovementHandler movementHandler;
    private IShootHandler shootHandler;
    private IFirepointHandler firepointHandler;
    [SerializeField] private Transform firepoint;
    [SerializeField] float firepointDistance;
    [SerializeField] float evadeDistance;

    private void Awake()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        movementHandler = new RigidbodyMovementHandler(rigidbody);
        weaponInstrument = GetComponent<WeaponInstrument>();
        playerDetectionHandler = GetComponent<PlayerDetectionHandler>();
        shootHandler = new ShootHandler(firepoint);
        firepointHandler = new FirepointHandler(firepoint,transform, firepointDistance);
    }
    public override void Action()
    {
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

        if(distanceToPlayer <= evadeDistance)
        {
            EvadePlayer(playerPosition);
        }
        else
        {
            AimAndShoot(playerPosition);
        }
    }
    public override void Idle()
    {
        movementHandler.Move(Vector3.zero,0);
    }
    public void Move(Vector3 direction)
    {
        movementHandler.Move(direction, Speed);
    }

    public void Shoot(Vector3 targetPosition) 
    {
        if (shootHandler.CanShoot(weaponInstrument))
        {
            shootHandler.Shoot(targetPosition, weaponInstrument,Damage);
        }
    }

    public void AimAndShoot(Vector3 targetPosition)
    {
        firepointHandler.Aim(targetPosition);
        Shoot(targetPosition);
    }

    public void EvadePlayer(Vector3 playerPosition)
    {
        Vector3 direction = (transform.position - playerPosition).normalized;
        Move(direction);
    }
}
