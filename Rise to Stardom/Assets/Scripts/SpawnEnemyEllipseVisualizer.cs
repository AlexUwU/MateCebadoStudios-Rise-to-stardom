using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyEllipseVisualizer : MonoBehaviour
{
    public Transform centerPoint;
    public float ellipseRadiusX;
    public float ellipseRadiusZ;
    public int ellipseResolution;
    private void OnDrawGizmos()
    {
        if (centerPoint == null) return;

        Gizmos.color = Color.yellow;
        Vector3 center = centerPoint.position;

        for (int i = 0; i < ellipseResolution; i++)
        {
            float angle1 = (i / (float)ellipseResolution) * Mathf.PI * 2;
            float angle2 = ((i + 1) / (float)ellipseResolution) * Mathf.PI * 2;

            Vector3 point1 = new Vector3(center.x + Mathf.Cos(angle1) * ellipseRadiusX, center.y, center.z + Mathf.Sin(angle1) * ellipseRadiusZ);
            Vector3 point2 = new Vector3(center.x + Mathf.Cos(angle2) * ellipseRadiusX, center.y, center.z + Mathf.Sin(angle2) * ellipseRadiusZ);

            Gizmos.DrawLine(point1, point2);
        }
    }
}
