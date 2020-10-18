using UnityEngine;

public class CasterTrap : MonoBehaviour
{
    public float lifeTime = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("PlayerInACasterTRAP");
            GameManager.Instantiate.playerIsDead = true;
        }
    }

    public void DecreaseLifeTime()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            Destroy(this.gameObject);
        }
    }
}