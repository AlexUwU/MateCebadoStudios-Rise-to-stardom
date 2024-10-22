using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public SpawnEnemyEllipseVisualizer ellipseVisualizer;
    public List<GameObject> spawnDoors = new List<GameObject>();
    public List<SpawnConfiguration> spawnConfigurations = new List<SpawnConfiguration>();
    public GameBehaviour gameBehaviour;
    void Start()
    {
        gameBehaviour = FindObjectOfType<GameBehaviour>();
    }

    public void SpawnEnemies()
    {
        foreach (SpawnConfiguration config in spawnConfigurations)
        {
            if (config.door != null && config.enemyPrefab != null)
            {
                for (int i = 0; i < config.enemyCount; i++)
                {
                    Vector3 directionToCenter = (ellipseVisualizer.centerPoint.position - config.door.transform.position).normalized;
                    float spawnDistance = 1.0f;

                    Vector3 spawnPosition = config.door.transform.position + directionToCenter * spawnDistance;

                    GameObject newEnemy = Instantiate(config.enemyPrefab, spawnPosition, Quaternion.identity);
                    Enemy enemyComponent = newEnemy.GetComponent<Enemy>();
                    if (enemyComponent != null)
                    {
                        enemyComponent.InitialPosition = GetRandomPointOnEllipse(
                            ellipseVisualizer.centerPoint.position,
                            ellipseVisualizer.ellipseRadiusX,
                            ellipseVisualizer.ellipseRadiusZ);

                        gameBehaviour.IncrementEnemyCount();
                    }
                }
            }
        }
    }
    private Vector3 GetRandomPointOnEllipse(Vector3 center, float radiusX, float radiusZ)
    {
        float angle = Random.Range(0f, Mathf.PI * 2);

        float randomRadiusX = Mathf.Sqrt(Random.Range(0f, 1f)) * radiusX; 
        float randomRadiusZ = Mathf.Sqrt(Random.Range(0f, 1f)) * radiusZ;

        float x = center.x + Mathf.Cos(angle) * randomRadiusX;
        float z = center.z + Mathf.Sin(angle) * randomRadiusZ;

        return new Vector3(x, center.y, z);
    }
}