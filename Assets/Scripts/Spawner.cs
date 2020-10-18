using UnityEngine;

public class Spawner : MonoBehaviour
{
    public CasterEnemy casterEnemyPrefab;
    public DefaultEnemy DefaultEnemyPrefab;

    private void Start()
    {
    }

    private void Update()
    {
    }

    internal void SpawnRandomEnemy()
    {
        Debug.Log("Spawned");
        var newEnemy = Instantiate(DefaultEnemyPrefab, transform.position, new Quaternion());
        GameManager.Instantiate.defaultEnemies.Add(newEnemy);
    }
}