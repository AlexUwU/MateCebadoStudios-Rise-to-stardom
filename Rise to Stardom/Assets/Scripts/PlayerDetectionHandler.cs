using UnityEngine;

public class PlayerDetectionHandler : MonoBehaviour, IPlayerDetectionHandler
{
    [SerializeField] private float detectionRange;

    public bool IsPlayerInRange(Vector2 position)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(player == null) return false;

        float distance = Vector2.Distance(position, player.transform.position);
        return distance <= detectionRange;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
