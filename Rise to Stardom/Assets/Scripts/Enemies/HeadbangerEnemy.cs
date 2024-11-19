using UnityEngine;

public class HeadbangerEnemy : Enemy
{
    private IMovementHandler movementHandler;

    public HUD hud;

    [SerializeField] private StunStateConfig stunConfig;

    public Animator anim;
    private float x;

 





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
        GetInput();
        if(playerDetectionHandler != null && playerDetectionHandler.IsEnabled() )
        {
            if (playerDetectionHandler.IsPlayerInRange(transform.position))
            {
                SetState(new AttackState(Player.Instance.playerTransform));
                anim.SetBool("Moving", true);
            }
            else
            {
                SetState(new ReturnInitialPositionState());
                anim.SetBool("Moving", false);
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

    private void GetInput(){

        if(transform.position.x > Player.Instance.playerTransform.position.x){
            anim.SetFloat("X", 1);
        }else if (transform.position.x < Player.Instance.playerTransform.position.x){
            anim.SetFloat("X", -1);
        }        
       
    }
}
