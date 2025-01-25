using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject mrDirtyPrefab;
    public Transform spawnPos;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), 0.5f, Random.Range(5, 10));
    }

    public void Spawn()
    {
        GameObject go = Instantiate(mrDirtyPrefab);
        go.transform.position = spawnPos.position;
    }
}
