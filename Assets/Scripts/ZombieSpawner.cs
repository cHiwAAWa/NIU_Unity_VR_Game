using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public ZombieFactory zombieFactory;

    [Header("Spawn Settings")]
    public float spawnInterval = 3f;    // 幾秒生一次
    public Transform[] spawnPoints;    // 可設定多個出生點

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnZombie();
            timer = 0f;
        }
    }

    void SpawnZombie()
    {
        // 隨機選擇出生點
        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];

        zombieFactory.CreateZombie(point.position);
    }
}
