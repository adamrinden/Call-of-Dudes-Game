using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public GameObject targetPrefab; // Reference to the target prefab
    public int maxTargets = 8; // Maximum number of targets
    public Vector3 spawnAreaMin = new Vector3(0.07f, 2.27f, 6.38f); // Min spawn range
    public Vector3 spawnAreaMax = new Vector3(5.68f, 5.68f, 2.27f); // Max spawn range

    private List<GameObject> activeTargets = new List<GameObject>();

    private void Start()
    {
        SpawnInitialTargets();
    }

    private void Update()
    {
        // Check if we need to spawn more targets
        if (activeTargets.Count < maxTargets)
        {
            SpawnTarget();
        }
    }

    private void SpawnInitialTargets()
    {
        for (int i = 0; i < maxTargets; i++)
        {
            SpawnTarget();
        }
    }

    private void SpawnTarget()
{
    // Random position within spawn range
    float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
    float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
    float z = Random.Range(spawnAreaMin.z, spawnAreaMax.z);
    Vector3 spawnPosition = new Vector3(x, y, z);

    // Instantiate the target with the prefab's rotation
    GameObject newTarget = Instantiate(targetPrefab, spawnPosition, Quaternion.Euler(90.0f,0.0f,Random.Range(0,360)));
    activeTargets.Add(newTarget);

    // Remove destroyed targets from the list
    newTarget.GetComponent<Target>().OnDestroyed += () => activeTargets.Remove(newTarget);
}

}
