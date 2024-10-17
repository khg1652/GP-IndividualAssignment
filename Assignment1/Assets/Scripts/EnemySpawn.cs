using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject prefab;
    public float startTime;
    public float endTime;
    public float spawnRate;
    public float rotationSpeed;
    public float spawnRangeX = 100f; // XÃà ·£´ý ¹üÀ§
    public float spawnRangeZ = 100f; // ZÃà ·£´ý ¹üÀ§
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("CancelInvoke", endTime);
    }
    void Spawn()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        float randomZ = Random.Range(-spawnRangeZ, spawnRangeZ);
        Vector3 spawnPosition = new Vector3(randomX, 0f, randomZ) + transform.position;
        //Debug.Log(spawnPosition);
        Instantiate(prefab, spawnPosition, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
