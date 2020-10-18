using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DefaultEnemy : MonoBehaviour
{
    private GameObject player;
    public NavMeshAgent agent;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instantiate.Player.direction != Vector2.zero)
            {
                Destroy(gameObject);
                Debug.Log("EnemyDead");
            }
            else
            {
                GameManager.Instantiate.KillPlayer();
            }
        }
    }
}