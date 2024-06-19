using UnityEngine;

public class FirepointHandler : IFirepointHandler
{
    private Transform firepointTransform;
    private Transform myTransform;
    private float firepointDistance;

    public FirepointHandler(Transform firepointTransform, Transform myTransform,float firepointDistance)
    {
        this.firepointTransform = firepointTransform;
        this.myTransform = myTransform;
        this.firepointDistance = firepointDistance;
    }

    public void Aim(Vector3 targetPosition)
    {
        Vector3 direction = (targetPosition - myTransform.position).normalized;
        Vector3 newFirePointPosition = myTransform.position + direction * firepointDistance;
        firepointTransform.position = newFirePointPosition;
        firepointTransform.LookAt(newFirePointPosition);
    }
}
