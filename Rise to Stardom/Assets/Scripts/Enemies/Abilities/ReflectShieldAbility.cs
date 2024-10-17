using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[CreateAssetMenu(fileName = "ReflectShieldAbility", menuName = "EnemyAbility/ReflectShieldAbility")]
public class ReflectShieldAbility : EnemyAbility
{
    [SerializeField] float radius;
    [SerializeField] string bulletTag;
    [SerializeField] float speedModifier;
    [SerializeField] float activeDuration;
    [SerializeField] float cooldown;
    [SerializeField] bool isEnabled;
    private Coroutine cooldownCoroutine;
    private bool isActive;
    public float Radius { get { return radius; } }
    public override void Use(Enemy enemy)
    {
        if (CanUse())
        {
            isActive = true;
            cooldownCoroutine = enemy.StartCoroutine(ActivateShieldForDuration(enemy));
        }
    }
    private IEnumerator ActivateShieldForDuration(Enemy enemy)
    {
        float timer = 0f;
        while (timer < activeDuration)
        {
            Collider[] hitColliders = Physics.OverlapSphere(enemy.transform.position, radius);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag(bulletTag))
                {
                    Rigidbody rb = hitCollider.GetComponent<Rigidbody>();
                    Vector3 direction = (hitCollider.transform.position - enemy.transform.position).normalized;
                    rb.velocity = direction * speedModifier;

                    ProyectilBase proyectil = hitCollider.GetComponent<ProyectilBase>();
                    if (proyectil != null)
                    {
                        proyectil.SetOwner(enemy.gameObject);
                    }
                };
            }
            timer += Time.deltaTime;
            yield return null;
        }

        isActive = false;
        cooldownCoroutine = enemy.StartCoroutine(CooldownCoroutine());
    }
    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(cooldown);
        cooldownCoroutine = null;
    }
    public override bool CanUse()
    {
        return cooldownCoroutine == null && isEnabled && !isActive;
    }
}
