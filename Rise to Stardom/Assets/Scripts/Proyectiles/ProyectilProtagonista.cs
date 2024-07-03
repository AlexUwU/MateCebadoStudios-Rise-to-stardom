using UnityEngine;

public class ProyectilProtagonista : ProyectilBase
{
    public override void OnTriggerEnter(Collider enemigo)
    {
        if (enemigo.tag == "Enemigo" || (enemigo.tag == "Player" && GetOwner().CompareTag("Enemigo")))
        {
            int damageInt = (int)damage;
            Debug.Log("A");
            IHealthHandler healthHandler = enemigo.gameObject.GetComponent<IHealthHandler>();
            if (healthHandler != null)
            {
                healthHandler.TakeDamage(damageInt);
            }
            Destroy(gameObject);
        }
    }
}
