using UnityEngine;

public class ZombieFactory : MonoBehaviour
{
    [Header("Zombie Prefab")]
    public GameObject zombiePrefab;

    // 工廠負責創造殭屍
    public GameObject CreateZombie(Vector3 position)
    {
        GameObject zombie = Instantiate(zombiePrefab, position, Quaternion.identity);
        return zombie;
    }
}
