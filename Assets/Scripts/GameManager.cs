using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player Player;
    public List<CasterTrap> casterTraps = new List<CasterTrap>();
    public List<CasterEnemy> casterEnemies = new List<CasterEnemy>();
    public List<DefaultEnemy> defaultEnemies = new List<DefaultEnemy>();
    private List<Spawner> spawners;
    public bool playerIsDead = false;
    public Spawner spawnerPrefab;
    private int NumberOfEnemies = 10;
    private int CurrentNumberOfEnemies;

    public static new GameManager Instantiate { get; private set; }

    // Start is called before the first frame update
    public void Awake()
    {
        Instantiate = this;
    }

    private void Start()
    {
        var spawn = GameObject.FindGameObjectsWithTag("Spawner");
        spawners = new List<Spawner>();
        foreach (var spawner in spawn)
        {
            var b = Instantiate(spawnerPrefab, spawner.transform.position, spawner.transform.rotation);
            spawners.Add(b);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (playerIsDead)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        casterTraps.RemoveAll(v => !v);
        defaultEnemies.RemoveAll(v => !v);
        foreach (var trap in casterTraps)
        {
            trap.DecreaseLifeTime();
        }

        CurrentNumberOfEnemies = casterEnemies.Count + defaultEnemies.Count;

        if (CurrentNumberOfEnemies < NumberOfEnemies - spawners.Count)
        {
            foreach (var spawner in spawners)
            {
                spawner.SpawnRandomEnemy();
            }
        }
    }
    public void KillPlayer()
    {
        playerIsDead = true;
    }
}