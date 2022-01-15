using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmeViseur : MonoBehaviour
{ 

	Vector3 posMouse;
    private Vector3 currentPosition;
    private Vector3 targetPosition;

	// Use this for initialization





private void FixedUpdate()
{
    currentPosition = transform.position;
       
    posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    targetPosition = currentPosition + new Vector3(0, 0, -currentPosition.x + posMouse.x); 
    transform.LookAt(targetPosition);



        

    }

}