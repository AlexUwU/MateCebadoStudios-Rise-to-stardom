using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{

    public GameBehaviour stateBoss;

    private IMovementHandler movementHandler;
    private WeaponInstrument weaponInstrument;
    private IShootHandler shootHandler;
    private IFirepointHandler firepointHandler;

    [SerializeField] private Transform firepoint;
    [SerializeField] float firepointDistance;
    [SerializeField] private List<EnemyAbility> phase1Abilities;
    [SerializeField] private List<EnemyAbility> phase2Abilities;
    [SerializeField] private List<EnemyAbility> phase3Abilities;
    private int currentPhase = 1;

    private new IHealthHandler healthHandler;
    private float maxHealth;
    [SerializeField] private float phase2Threshold;
    [SerializeField] private float phase3Threshold;

    public int CurrentPhase { get { return currentPhase; } }
    public List<IEnemyAbility> CurrentAbilities { get; private set; }
    public List<EnemyAbility> Phase1Abilities { get { return phase1Abilities; } }
    public List<EnemyAbility> Phase2Abilities { get { return phase2Abilities; } }
    public List<EnemyAbility> Phase3Abilities { get { return phase3Abilities; } }


    public override void Start()
    {
        base.Start();
        stateBoss = FindObjectOfType<GameBehaviour>();
    }
    protected override void Awake()
    {
        base.Awake();
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        movementHandler = new RigidbodyMovementHandler(rigidbody);
        weaponInstrument = GetComponent<WeaponInstrument>();
        playerDetectionHandler = GetComponent<PlayerDetectionHandler>();
        shootHandler = new ShootHandler(firepoint);
        firepointHandler = new FirepointHandler(firepoint, transform, firepointDistance);
        AttackBehaviour = new BossAttackBehaviour(this); ;

        SetPhase(currentPhase);

        healthHandler = GetComponent<HealthHandler>();
        maxHealth = healthHandler.Health;
    }
    public override void Update()
    {
        base.Update();

        if (ChangePhase())
        {
            currentPhase++;
            SetPhase(currentPhase);
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
    public void Aim(Vector3 targetPosition)
    {
        firepointHandler.Aim(targetPosition);
    }

    private void SetPhase(int phase)
    {
        IEnemyState newState;
        switch (phase)
        {
            case 1:
                newState = new BossPhase1State(this);
                break;
            case 2:
                newState = new BossPhase2State(this);
                break;
            case 3:
                newState = new BossPhase3State(this);
                break;
            default:
                newState = new BossPhase1State(this);
                break;
        }
        SetState(newState);
    }
    public void SetAbilitiesForPhase(List<IEnemyAbility> abilities)
    {
        CurrentAbilities = abilities;
    }
    private bool ChangePhase()
    {
        float currentHealth = healthHandler.Health;

        float phase2Change = phase2Threshold * maxHealth;
        float phase3Change = phase3Threshold * maxHealth;

        if (currentHealth <= phase2Change && currentPhase < 2)
        {
            return true;
        }
        else if (currentHealth <= phase3Change && currentPhase < 3)
        {
            stateBoss.boss = true;
            return true;
        }

        return false;
    }
}
