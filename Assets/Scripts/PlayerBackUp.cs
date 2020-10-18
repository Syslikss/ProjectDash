#region FirstUpdate

//using UnityEngine;

//public class PlayerBackUp : MonoBehaviour
//{
//    private CharacterController controller;
//    private bool fixedMove = false;
//    private float playerDashRange = 2000.0f;
//    private float dashSpeed = 0.1f;
//    private Vector2 swipe = Vector2.zero;
//    private float swipeDump = 0.0f;

//    private Vector2 firstPressPos;
//    private Vector2 secondPressPos;

//    private Animator anim;

//    private void Start()
//    {
//        controller = gameObject.GetComponent<CharacterController>();
//        anim = gameObject.GetComponent<Animator>();
//    }

//    private void Update()
//    {
//        if (!fixedMove)
//        {
//            swipe = Swipe();
//            swipeDump = swipe.magnitude;

//            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("attack_B"))
//                anim.Play("idle");
//        }
//        else
//        {
//            anim.Play("attack_B");
//        }
//        if (swipeDump < 0.1)
//        {
//            fixedMove = false;
//        }
//        else
//        {
//            fixedMove = true;
//            swipeDump -= dashSpeed;
//        }

//        Vector3 move = new Vector3(swipe.x, 0, swipe.y);
//        controller.Move(move * Time.deltaTime * playerDashRange * dashSpeed);

//        if (move != Vector3.zero)
//        {
//            gameObject.transform.forward = move;
//        }
//    }

//    public Vector2 Swipe()
//    {
//        var currentSwipe = new Vector2();
//        if (Input.touches.Length > 0)
//        {
//            Touch t = Input.GetTouch(0);
//            if (t.phase == TouchPhase.Began)
//            {
//                firstPressPos = new Vector2(t.position.x, t.position.y);
//            }
//            if (t.phase == TouchPhase.Ended)
//            {
//                secondPressPos = new Vector2(t.position.x, t.position.y);
//                currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
//                currentSwipe.Normalize();
//            }
//        }
//        return currentSwipe;
//    }
//}

#endregion FirstUpdate

#region SecondUpdate

//using UnityEngine;

//public class Player : MonoBehaviour
//{
//    private CharacterController controller;
//    private Animator animations;

//    private readonly float dashTime = 0.3f;
//    private readonly float dashRange = 100f; //From 50 to >100

//    private float dashTimeDump = 0f;
//    private Vector2 direction = Vector2.zero;

//    private Vector2 firstPressPos;
//    private Vector2 secondPressPos;

//    private void Start()
//    {
//        controller = gameObject.GetComponent<CharacterController>();
//        animations = gameObject.GetComponent<Animator>();
//    }

//    private void Update()
//    {
//        if (direction.magnitude == 0)
//        {
//            direction = GetSwipe();
//            dashTimeDump = dashTime;
//            if (!animations.GetCurrentAnimatorStateInfo(0).IsName("attack_B"))
//            {
//                animations.Play("idle");
//            }
//        }
//        else
//        {
//            animations.Play("attack_B");
//        }

//        if (dashTimeDump > 0.1)
//        {
//            dashTimeDump -= Time.deltaTime;
//        }
//        else
//        {
//            direction = new Vector2(0, 0);
//        }

//        Vector3 move = new Vector3(direction.x, 0, direction.y);
//        controller.Move(move * Time.deltaTime * (dashRange / dashTime));

//        if (move != Vector3.zero)
//        {
//            gameObject.transform.forward = move;
//        }
//    }

//    public Vector2 GetSwipe()
//    {
//        var currentSwipe = new Vector2();
//        if (Input.touches.Length > 0)
//        {
//            Touch t = Input.GetTouch(0);
//            if (t.phase == TouchPhase.Began)
//            {
//                firstPressPos = new Vector2(t.position.x, t.position.y);
//            }
//            if (t.phase == TouchPhase.Ended)
//            {
//                secondPressPos = new Vector2(t.position.x, t.position.y);
//                currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
//                currentSwipe.Normalize();
//            }
//        }
//        return currentSwipe;
//    }
//}

#endregion SecondUpdate

#region Trash3
//using UnityEngine;

//public class Player3 : MonoBehaviour
//{
//    private CharacterController controller;
//    private Animator animations;

//    private readonly float dashTime = 0.3f;
//    private readonly float dashRange = 100f; //From 50 to >100

//    private float dashTimeDump = 0f;
//    private Vector2 direction = Vector2.zero;

//    private Vector2 firstPressPos;
//    private Vector2 secondPressPos;
//    private bool moving;

//    private void Start()
//    {
//        controller = gameObject.GetComponent<CharacterController>();
//        animations = gameObject.GetComponent<Animator>();
//    }

//    private void Update()
//    {
//        if (direction.magnitude == 0)
//        {
//            direction = GetSwipe();
//            dashTimeDump = dashTime;
//            if (!animations.GetCurrentAnimatorStateInfo(0).IsName("attack_B"))
//            {
//                animations.Play("idle");
//            }
//        }
//        else
//        {
//            if (!animations.GetCurrentAnimatorStateInfo(0).IsName("attack_B"))
//            {
//                animations.Play("attack_B");
//            }
//        }

//        if (dashTimeDump > 0.1)
//        {
//            dashTimeDump -= Time.deltaTime;
//        }
//        else
//        {
//            direction = Vector2.zero;
//        }

//        Vector3 move = new Vector3(direction.x, 0, direction.y);
//        controller.Move(move * Time.deltaTime * ((moving == true ? 10f : dashRange) / dashTime));

//        if (moving)
//        {
//            dashTimeDump = 0;
//        }

//        if (move != Vector3.zero)
//        {
//            gameObject.transform.forward = move;
//        }
//    }

//    public Vector2 GetSwipe()
//    {
//        var currentSwipe = new Vector2();

//        if (Input.touches.Length > 0)
//        {
//            var t = Input.GetTouch(0);
//            if (t.phase == TouchPhase.Began)
//            {
//                firstPressPos = new Vector2(t.position.x, t.position.y);
//            }
//            if (t.phase == TouchPhase.Ended && t.deltaPosition.magnitude > 10f && !moving)
//            {
//                secondPressPos = new Vector2(t.position.x, t.position.y);
//                currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
//                currentSwipe.Normalize();
//            }
//            else
//            {
//                moving = true;
//                secondPressPos = new Vector2(t.position.x, t.position.y);
//                currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
//                currentSwipe.Normalize();
//            }
//            if (t.phase == TouchPhase.Ended && moving)
//            {
//                moving = false;
//                currentSwipe = Vector2.zero;
//            }
//        }
//        return currentSwipe;
//    }
//}
#endregion