using UnityEngine;

public class PlayerDetectionHandler : MonoBehaviour, IPlayerDetectionHandler
{
    [SerializeField] private float detectionRange;
    private bool isEnabled = true;

    public bool IsPlayerInRange(Vector3 position)
    {
        if (!isEnabled) { return false; }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return false;

        float distance = Vector3.Distance(position, player.transform.position);
        return distance <= detectionRange;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

    public void SetEnabled(bool enabled)
    {
        isEnabled = enabled;
    }
    public bool IsEnabled()
    {
        return isEnabled;
    }
}
