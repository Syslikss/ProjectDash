using UnityEngine;

public class SimpleTrap : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instantiate.Player.direction == Vector2.zero)
            {
                Debug.Log("PlayerInASimpleTRAP");
                GameManager.Instantiate.KillPlayer();

            }
        }
    }
}