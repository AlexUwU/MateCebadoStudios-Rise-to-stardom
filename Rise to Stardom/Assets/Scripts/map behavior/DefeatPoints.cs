using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatPoints : MonoBehaviour
{
    [SerializeField]private List<Transform> points = new List<Transform>();
    public List<Transform> Points { get { return points; } }
    public Transform GetNearestPoint(Vector3 position)
    {
        Transform nearestPoint = null;
        float minDistance = float.MaxValue;

        foreach (var point in points)
        {
            float distance = Vector3.Distance(position, point.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestPoint = point;
            }
        }

        return nearestPoint;
    }
    public void AddPoint(Transform newPoint)
    {
        if (!points.Contains(newPoint))
        {
            points.Add(newPoint);
        }
    }
}
