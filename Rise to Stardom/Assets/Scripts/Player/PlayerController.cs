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
    private PlayerStats playerStats;
    private Inventory inventory;

    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform pointer;
    [SerializeField] private float firePointDistance;

    public Animator anim;

    private bool moving;

    private float x;
    private float y;
    private Vector2 input;

    private SpriteRenderer spRenderer;

  

    private void Start()
    {
        inputHandler = new PlayerInputHandler();
        movementHandler = new RigidbodyMovementHandler(GetComponent<Rigidbody>());
        firepointHandler = new FirepointHandler(firePoint, transform, firePointDistance);
        this.spRenderer = this.GetComponentInChildren<SpriteRenderer>();
        

        shootHandler = new ShootHandler(firePoint);

        fireModes = new Dictionary<FireMode, IFireModeHandler>
        {
            { FireMode.Auto, new AutoFireMode()},
            { FireMode.Semi, new SemiFireMode() }
        };

        playerStats = GetComponent<PlayerStats>();
        inventory = GetComponent<Inventory>();
    }

    private void Update()
    {   
        GetInput();
        Animate();

        Vector3 inputMovement = inputHandler.GetInputMovement();
        float moveSpeed = playerStats.MoveSpeed;
        movementHandler.Move(inputMovement,moveSpeed);

        Vector3 pointerTargetPosition = pointer.position;
        firepointHandler.Aim(pointerTargetPosition);

       

        WeaponInstrument equippedWeapon = inventory.GetWeaponManager().GetEquippedWeapon();
        if (equippedWeapon != null)
        {
            IFireModeHandler fireModeHandler = fireModes[equippedWeapon.fireMode];
            fireModeHandler.HandleFireMode(inputHandler, shootHandler, pointer, equippedWeapon, playerStats.Damage, playerStats.AttackSpeed, playerStats.NoteSpeed);
            shootHandler.Update();

            if (inputHandler.IsUsingAbilityWeapon() && equippedWeapon.instrumentAbiltity != null)
            {
                equippedWeapon.instrumentAbiltity.Activate();
            }
        }

        if (inputHandler.IsUsingConsumable()) 
        {
            inventory.GetConsumableManager().UseCurrentConsumable(gameObject);
        }

        if (inputHandler.IsSwitchingConsumableLeft()) 
        {
            inventory.GetConsumableManager().SwitchConsumable(false);
        }

        if (inputHandler.IsSwitchingConsumableRight()) 
        {
            inventory.GetConsumableManager().SwitchConsumable(true);
        }
    }

    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        input = new Vector2(x, y);
        input.Normalize();
    }

    private void Animate()
    {
        if (input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {   
            this.spRenderer.flipX = pointer.transform.position.x < this.transform.position.x;     
            moving = false;
        }

        if (moving)
        {
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);
            spRenderer.flipX=false;
        }

        

        anim.SetBool("Moving", moving);
    }

    void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "Damage")
        {
            anim.SetTrigger("Hit");
            Destroy(target.gameObject);
            
        }
        else if(target.gameObject.tag == "Enemy")
        {
            anim.SetTrigger("Hit");
        }
    }

    public void ChangeWeapon(){
        anim.SetTrigger("InstrumentChange");
        
    }
}
