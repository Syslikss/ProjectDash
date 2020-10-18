using System;
using UnityEngine;
using UnityEngine.AI;

public class CasterEnemy : MonoBehaviour
{
    private GameObject player;
    public NavMeshAgent agent;
    public float castRange = 40f;
    public float runRange = 30f;
    public float trapScatter = 20f;
    public CasterTrap casterTrap;

    public float castTime = .5f;
    private float castTimeDump = 0f;

    public float castCD = 5f;
    private float castCDDump = 0f;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Vector3 distance = player.transform.position - gameObject.transform.position;
        if (castTimeDump <= 0 || castCDDump > 0)
        {
            if (distance.magnitude > castRange)
            {
                agent.destination = player.transform.position;
            }
            if (distance.magnitude < runRange)
            {
                agent.destination = -distance.normalized * 30 + gameObject.transform.position;
            }
            else if (distance.magnitude < castRange)
            {
                if (castTimeDump <= 0)
                {
                    castTimeDump = castTime;
                }
                agent.destination = gameObject.transform.position;
            }
        }

        if (castTime == castTimeDump && castCDDump <= 0)
        {
            Debug.Log("Atc");
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    if (Math.Abs(i) == Math.Abs(j) && Math.Abs(j) != 0)
                    {
                        CasterTrap newTrap = Instantiate(casterTrap,
                            player.transform.position + new Vector3(i * trapScatter, 0, j * trapScatter),
                            new Quaternion());
                        GameManager.Instantiate.casterTraps.Add(newTrap);
                    }
                }
            castCDDump = castCD;
        }

        if (castTimeDump > 0)
        {
            castTimeDump -= Time.deltaTime;
        }
        if (castCDDump > 0)
        {
            castCDDump -= Time.deltaTime;
        }
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
        }
    }
}