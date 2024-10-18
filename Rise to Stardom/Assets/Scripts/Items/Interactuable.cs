using UnityEngine;

public class Interactuable : MonoBehaviour
{
    public float radio = 3f;
    bool isFocus = false;
    Transform jugador;
    bool hasInteracted = false;

    #region Funciones a ser sobreescritas con la herencia.
    public virtual void Interact()
    {
    }
    public virtual void OnTriggerEnter(Collider Player)
    {
    }
    public virtual void OnTriggerStay(Collider Player)
    {
    }
    public virtual void OnTriggerExit(Collider Player)
    {
    }
    #endregion

    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(jugador.position, transform.position);
            if (distance <= radio*1.25)
            {
                Interact();
                hasInteracted = true;
            }
            else
            {
                Debug.Log("Fuera del rango");
                hasInteracted = true;
            }
        }
    }

    public void OnFocused(Transform jugadorTransform)
    {
        isFocus = true;
        jugador = jugadorTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        jugador = null;
        hasInteracted = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
