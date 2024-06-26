using UnityEngine;

public class ProyectilProtagonista : ProyectilBase
{
    public override void OnTriggerEnter(Collider enemigo)
    {
        if (enemigo.tag == "Enemigo")
        {
            Debug.Log("A");
            IHealthHandler healthHandler = enemigo.gameObject.GetComponent<IHealthHandler>();
            if (healthHandler != null)
            {
                healthHandler.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
