using UnityEngine;

public class HeadbangerEnemy : Enemy
{
    private IMovementHandler movementHandler;

    public HUD hud;

    [SerializeField] private StunStateConfig stunConfig;


    protected override void Awake()
    {
        base.Awake();
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        movementHandler = new RigidbodyMovementHandler(rigidbody);
        playerDetectionHandler = GetComponent<PlayerDetectionHandler>();
        AttackBehaviour = new HeadbangerAttackBehaviour();
    }

    public override void Update()
    {
        base.Update();
        if(playerDetectionHandler != null && playerDetectionHandler.IsEnabled() )
        {
            if (playerDetectionHandler.IsPlayerInRange(transform.position))
            {
                SetState(new AttackState(Player.Instance.playerTransform));
            }
            else if (enemyStateManager.currentStateName != "IdleState")
            {
                SetState(new ReturnInitialPositionState());
            }
        }
    }

    public override void Move(Vector3 direction)
    {
        movementHandler.Move(direction, MoveSpeed.Value);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerStats playerStats = Player.Instance?.PlayerStats;
            if(playerStats != null)
            {
                playerStats.CurrentHealth -= Damage.Value;
                hud.DisabledLives(1);
                SetState(stunConfig.CreateState());
            }
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy otherEnemy = collision.gameObject.GetComponent<Enemy>();
            if (otherEnemy != null && enemyStateManager.currentStateName == "ConfusionState")
            {
                otherEnemy.TakeDamage(Damage.Value);
                TakeDamage(Damage.Value);
            }
        }
    }
}
