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

    private void Start()
    {
        inputHandler = new PlayerInputHandler();
        movementHandler = new RigidbodyMovementHandler(GetComponent<Rigidbody>());
        firepointHandler = new FirepointHandler(firePoint, transform, firePointDistance);

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

            if (Input.GetKeyDown(KeyCode.Q) && equippedWeapon.instrumentAbiltity != null)
            {
                equippedWeapon.instrumentAbiltity.Activate();
            }
        }

        if (Input.GetKeyDown(KeyCode.C)) 
        {
            inventory.GetConsumableManager().UseCurrentConsumable(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            inventory.GetConsumableManager().SwitchConsumable(false);
        }

        if (Input.GetKeyDown(KeyCode.X)) 
        {
            inventory.GetConsumableManager().SwitchConsumable(true);
        }
    }

    private void GetInput(){
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        input = new Vector2(x, y);
        input.Normalize();
    }

    private void Animate(){
        if(input.magnitude > 0.1f || input.magnitude < -0.1f){
            moving = true;
        }
        else{
        moving = false;
        }

        if(moving){
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);
        }

        anim.SetBool("Moving", moving);
    }

    void OnCollisionEnter(Collision target){
        if (target.gameObject.tag == "DamageSource" || target.gameObject.tag == "Enemy"){
            anim.SetTrigger("Hit");
        }
    }
}
