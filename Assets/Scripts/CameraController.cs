using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public float smoothTime;
    private Vector3 velocity = Vector3.zero;
    private Vector3 d;
    [SerializeField]
    private float cameraDistancePersent = 1f;


    private void Start()
    {
        d = new Vector3(0, 150, -260);
        gameObject.transform.TransformPoint(0, 0, 0);
    }

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, 
                                                player.transform.position + d * cameraDistancePersent, 
                                                ref velocity, smoothTime);
    }
}