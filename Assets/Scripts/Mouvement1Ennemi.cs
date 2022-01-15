using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Mouvement1Ennemi : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 3;
    [SerializeField] private Animator characterAnimator;
    private float vertical;
    private float horizontal;
    private Vector3 currentPosition;
    private Vector3 targetPosition;

    private void Start()
    {
        Debug.Log("Hello, World");
        vertical = 1;
        horizontal = 0;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hello, World4GEFDYDFT");
        if (other.gameObject.CompareTag("Mur"))
        {
            Debug.Log("Hello, World");

            vertical = vertical * -1;
            FixedUpdate();
        }
    }
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");

    private void FixedUpdate()
    {

        characterAnimator.SetBool(IsWalking, vertical != 0 || horizontal != 0);
        currentPosition = transform.position;
        targetPosition = currentPosition + new Vector3(horizontal, vertical, 0);
        
        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, Time.deltaTime * speed);

    }


}
