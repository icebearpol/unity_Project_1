using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    public List<Anomaly> anomalies;
    public float spawnInterval = 8f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnAnomaly();
            timer = 0f;
        }
    }

    void SpawnAnomaly()
    {
        List<Anomaly> inactive = anomalies.FindAll(a => !a.isActive);

        if (inactive.Count == 0)
        {
            Debug.Log("All anomalies active!");
            return;
        }

        int index = Random.Range(0, inactive.Count);
        inactive[index].Activate();

        Debug.Log("Anomaly Activated: " + inactive[index].name);
    }
}