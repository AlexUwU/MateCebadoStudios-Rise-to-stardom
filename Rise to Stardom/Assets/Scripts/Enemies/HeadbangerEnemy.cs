using UnityEngine;

public class HeadbangerEnemy : Enemy
{
    private IMovementHandler movementHandler;

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
        if(playerDetectionHandler != null && playerDetectionHandler.IsEnabled())
        {
            if (playerDetectionHandler.IsPlayerInRange(transform.position))
            {
                SetState(new AttackState(Player.Instance.playerTransform));
            }
            else
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
                SetState(stunConfig.CreateState());
            }
        }
<<<<<<< Updated upstream
    }
    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "Player"))
=======
        else if (collision.gameObject.CompareTag("Enemy"))
>>>>>>> Stashed changes
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
