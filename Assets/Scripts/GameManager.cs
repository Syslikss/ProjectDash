using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    private bool IsPaused = false;
    [SerializeField]
    private GameObject pauseCanvas;
    public int killCount;
    public Text textKillCount;

    public static new GameManager Instantiate { get; private set; }

    public void Awake()
    {
        Instantiate = this;
        pauseCanvas.SetActive(false);
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
        textKillCount.text = $"Kill Count: {killCount}";

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

    public void PauseButtonPressed()
    {
        if (IsPaused)
        {
            pauseCanvas.SetActive(false);
            Time.timeScale = 1f;
            IsPaused = false;
        }
        else
        {
            pauseCanvas.SetActive(true);
            Time.timeScale = 0f;
            IsPaused = true;
        }
    }


    public void AsyncLoadingMenu()
    {
        PauseButtonPressed();
        StartCoroutine(LoadMenu());
    }

    IEnumerator LoadMenu()
    {
        var load = SceneManager.LoadSceneAsync("Menu");

        while (!load.isDone)
        {
            yield return null;
        }
    }
}