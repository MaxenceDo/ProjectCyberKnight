using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 3;
    [SerializeField] private Animator characterAnimator;
    private float vertical;
    private float horizontal;
    private Vector3 currentPosition;
    private Vector3 targetPosition;

    Rigidbody2D rb;
    Vector2 dir;

    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        dir.y = Input.GetAxisRaw("Vertical");
        dir.x = Input.GetAxisRaw("Horizontal");
        characterAnimator.SetBool(IsWalking, dir.x != 0 || dir.y != 0);
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
    }





}