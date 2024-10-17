using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class DispararJugador : MonoBehaviour
{
    private IInputHandler inputHandler;
    private IShootHandler shootHandler;
    private IFirepointHandler firepointHandler;

    [SerializeField] private Transform firePoint;
    [SerializeField] private float firePointDistance;
    [SerializeField] private GameObject proyectil;
    private void Start()
    {
        inputHandler = new PlayerInputHandler();
        shootHandler = new ShootHandler(firePoint);
        firepointHandler = new FirepointHandler(firePoint, transform, firePointDistance);
    }

    public void Disparar(RaycastHit mouse, float damage, float speed)
    {

        Vector3 pointerPosition = mouse.point;
        Vector3 targetPosition = mouse.point;
        Vector3 firePointPosition = firePoint.position;
        Vector3 direction = (targetPosition - firePointPosition).normalized;
        direction.y = 0f;

        GameObject proy = GameObject.Instantiate(proyectil, firePointPosition, Quaternion.identity);
        proy.GetComponent<Rigidbody>().velocity = direction * speed;

        ProyectilBase buletNoteComponent = proy.GetComponent<ProyectilBase>();
        buletNoteComponent.damage = damage;
    }
    }

