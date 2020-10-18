using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Animator animations;

    public float dashRange = 100f; //From 50 to >100
    private readonly float dashCD = .5f;
    private float dashCDDump = 0f;

    private readonly float dashTime = 0.3f;
    private float dashTimeDump = 0f;
    public Vector2 direction = Vector2.zero;

    private Vector2 firstPressPos;
    private Vector2 secondPressPos;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animations = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (direction.magnitude == 0 && dashCDDump <= 0)
        {
            direction = GetSwipe();
            dashTimeDump = dashTime;
            if (!animations.GetCurrentAnimatorStateInfo(0).IsName("attack_B"))
            {
                animations.Play("idle");
            }
        }
        else
        {
            if (!animations.GetCurrentAnimatorStateInfo(0).IsName("attack_B"))
            {
                animations.Play("attack_B");
            }
        }

        if (dashTimeDump > 0.1)
        {
            dashTimeDump -= Time.deltaTime;
        }
        else
        {
            direction = new Vector2(0, 0);
        }
        if (dashCDDump > 0)
        {
            dashCDDump -= Time.deltaTime;
        }

        Vector3 move = new Vector3(direction.x, 0, direction.y);
        controller.Move(move * Time.deltaTime * (dashRange / dashTime));

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }

    

    

    public Vector2 GetSwipe()
    {
        var currentSwipe = new Vector2();
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                secondPressPos = new Vector2(t.position.x, t.position.y);
                currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
                currentSwipe.Normalize();
                dashCDDump = dashCD;
            }
        }
        return currentSwipe;
    }
}