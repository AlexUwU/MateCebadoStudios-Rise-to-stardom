using UnityEngine;

public class FanRangeEnemy : Enemy
{
    private IMovementHandler movementHandler;
    private IShootHandler shootHandler;
    private IFirepointHandler firepointHandler;
    
    [SerializeField] private Transform firepoint;
    [SerializeField] float firepointDistance;
    [SerializeField] float evadeDistance;
    [SerializeField] Stat attackSpeed;
    [SerializeField] Stat bulletSpeed;
    [SerializeField] private WeaponInstrument weaponInstrument;
    public Stat AttackSpeed => attackSpeed;
    public Stat BulletSpeed => bulletSpeed;
    
    public Animator anim;
    private bool moving;

    private float x;
    private float y;

    private SpriteRenderer spRenderer;


    protected override void Awake()
    {
        base.Awake();
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        movementHandler = new RigidbodyMovementHandler(rigidbody);
        playerDetectionHandler = GetComponent<PlayerDetectionHandler>();
        shootHandler = new ShootHandler(firepoint);
        firepointHandler = new FirepointHandler(firepoint, transform, firepointDistance);
        AttackBehaviour = new FanRangeAttackBehaviour();
        this.spRenderer = this.GetComponentInChildren<SpriteRenderer>();
    }
    public override void Update()
    {
        base.Update();
        GetInput();
        shootHandler.Update();
        this.spRenderer.flipX = Player.Instance.playerTransform.position.x > this.transform.position.x;
        if (playerDetectionHandler.IsPlayerInRange(transform.position) && playerDetectionHandler != null)
        {
            Vector3 playerPosition = Player.Instance.playerTransform.position;
            float distanceToPlayer = Vector3.Distance(transform.position, playerPosition);

            if (distanceToPlayer <= evadeDistance)
            {
                SetState(new EvadeState());
                anim.SetBool("Moving",true);
                
            }
            else
            {
                Move(Vector3.zero);
                anim.SetBool("Moving", false);
                anim.SetTrigger("Attack");
                SetState(new AttackState(Player.Instance.playerTransform));
            }
        }
        else if (playerDetectionHandler.IsEnabled())
        {
            SetState(new ReturnInitialPositionState());
            anim.SetBool("Moving", false);
        }
    }
    public override void Move(Vector3 direction)
    {
        movementHandler.Move(direction, MoveSpeed.Value);
    }

    public void Shoot(Vector3 targetPosition)
    {
        if (shootHandler.CanShoot())
        {
            shootHandler.Shoot(targetPosition, weaponInstrument, Damage.Value,attackSpeed.Value,bulletSpeed.Value);
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

    private void GetInput(){
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }
}