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
                SetState(new AttackState(GameObject.FindGameObjectWithTag("Player").transform));
            }
            else
            {
                SetState(new ReturnInitialPositionState());
            }
        }
    }

    public override void Move(Vector3 direction)
    {
        movementHandler.Move(direction, Speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") )
        {
            Debug.Log("Estoy chocando");
            HealthHandler healthHandlerPlayer = collision.gameObject.GetComponent<HealthHandler>();
            if(healthHandlerPlayer != null)
            {
                healthHandlerPlayer.TakeDamage(Damage);
                SetState(stunConfig.CreateState());
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "Player"))
        {
            Debug.Log("Estoy chocando");
            ProtagonistaEstadisticas vidaJugador = objetivo.gameObject.GetComponent<ProtagonistaEstadisticas>();
            if(vidaJugador != null)
                vidaJugador.RecibirDmg((float)Damage);
        }
    }
}
