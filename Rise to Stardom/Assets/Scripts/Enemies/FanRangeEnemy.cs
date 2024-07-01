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

    protected override void Awake()
    {
        base.Awake();
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        movementHandler = new RigidbodyMovementHandler(rigidbody);
        weaponInstrument = GetComponent<WeaponInstrument>();
        playerDetectionHandler = GetComponent<PlayerDetectionHandler>();
        shootHandler = new ShootHandler(firepoint);
        firepointHandler = new FirepointHandler(firepoint, transform, firepointDistance);
        AttackBehaviour = new FanRangeAttackBehaviour();
    }
    public override void Update()
    {
        base.Update();

        if (playerDetectionHandler.IsPlayerInRange(transform.position))
        {
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

            if (distanceToPlayer <= evadeDistance)
            {
                SetState(new EvadeState());
            }
            else
            {
                Move(Vector3.zero);
                SetState(new AttackState(GameObject.FindGameObjectWithTag("Player").transform));
            }
        }
        else if (playerDetectionHandler.IsEnabled())
        {
            SetState(new IdleState());
        }
    }
    public override void Move(Vector3 direction)
    {
        movementHandler.Move(direction, Speed);
    }

    public void Shoot(Vector3 targetPosition)
    {
        if (shootHandler.CanShoot())
        {
            shootHandler.Shoot(targetPosition, weaponInstrument, Damage);
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