using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaSpawner : MonoBehaviour
{

    public GameObject pelotaPrefab;
    public float spawnRate = 1f;
    public float zRange = 8f; // Cambiado para el rango en el eje Z
    public float ySpawnPosition = 10f;

    void Start()
    {
        InvokeRepeating("SpawnPelota", 1f, spawnRate);
    }

    void SpawnPelota()
    {
        Vector3 spawnPosition = new Vector3(0, ySpawnPosition, Random.Range(-zRange, zRange));
        Instantiate(pelotaPrefab, spawnPosition, Quaternion.identity);
    }
}
