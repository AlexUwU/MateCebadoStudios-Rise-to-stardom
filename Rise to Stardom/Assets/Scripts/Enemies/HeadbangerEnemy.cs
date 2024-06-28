using UnityEngine;

public class HeadbangerEnemy : Enemy
{
    private IMovementHandler movementHandler;
    private Vector3 initialPosition;
    private bool isStunned = false;
    [SerializeField]private float stunDuration;
    private float stunTimer;

    private void Awake()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        movementHandler = new RigidbodyMovementHandler(rigidbody);
        playerDetectionHandler = GetComponent<PlayerDetectionHandler>();
        initialPosition = transform.position;
    }

    public override void Update()
    {
        base.Update();
        if (isStunned)
        {
            stunTimer -= Time.deltaTime;
            if(stunTimer <= 0)
            {
                stunTimer = 0;
                isStunned=false;
            }
        }
    }

    public override void Action()
    {
        if (!isStunned)
        {
            Vector3 enemyPosition = transform.position;
            Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector3 direction = (playerPosition - enemyPosition).normalized;
            Move(direction);
        }
        else
        {
            movementHandler.Move(Vector3.zero, 0);
        }
    }

    public override void Idle()
    {
        if(!isStunned)
        {
            Vector3 direction = (initialPosition - transform.position).normalized;

            if (Vector3.Distance(transform.position, initialPosition) > 0.1f)
            {
                Move(direction);
            }
            else
            {
                movementHandler.Move(Vector3.zero, 0);
            }
        }
    }
    public void Move(Vector3 direction)
    {
        movementHandler.Move(direction, Speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && !isStunned)
        {
            Debug.Log("Estoy chocando");
            HealthHandler healthHandlerPlayer = collision.gameObject.GetComponent<HealthHandler>();
            if(healthHandlerPlayer != null)
            {
                healthHandlerPlayer.TakeDamage(Damage);
            }
            isStunned = true;
            stunTimer = stunDuration;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if ((other.tag == "Player") && !isStunned)
        {
            Debug.Log("Estoy chocando");
            ProtagonistaEstadisticas vidaJugador = objetivo.gameObject.GetComponent<ProtagonistaEstadisticas>();
            if(vidaJugador != null)
                vidaJugador.RecibirDmg((float)Damage);
            isStunned = true;
            stunTimer = stunDuration;
        }
    }
}
