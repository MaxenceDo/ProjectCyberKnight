using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationArme : MonoBehaviour
{
    Vector3 posMouse;
    private Vector3 currentPosition;
    private Vector3 targetPosition;
    public Transform target; 
    public Transform target2;

    //void FixedUpdate()
    //{
        //posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    currentPosition = target2.position;
    //    float deg = Mathf.Acos(Mathf.Abs((-currentPosition.x + posMouse.x) * (-currentPosition.x + posMouse.x)) / Mathf.Abs(((-currentPosition.y + posMouse.y) * (-currentPosition.y + posMouse.y)) + ((-currentPosition.x + posMouse.x) * (-currentPosition.x + posMouse.x))));

    //    if (-currentPosition.y + posMouse.y <= 0 && -currentPosition.x + posMouse.x > 0) { transform.eulerAngles = new Vector3(0, 0, 360 - (deg * Mathf.Rad2Deg)); }
    //    else if (-currentPosition.y + posMouse.y <= 0 && -currentPosition.x + posMouse.x <= 0) { transform.eulerAngles = new Vector3(0, 0,  - (deg * Mathf.Rad2Deg)); }
    //    else { transform.eulerAngles = new Vector3(0, 0, deg * Mathf.Rad2Deg); }


    //    if (-currentPosition.x + posMouse.x < 0) {
    //        transform.localScale = new Vector3(-2, 2, 0);
    //        transform.rotation = Quaternion.Inverse(target.rotation); }
    //    else { transform.localScale = new Vector3(2, 2, 0); }





    //}

    public int rotationOffset = 0;

    void Update()
    {
        posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPosition = target2.position;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
        if (-currentPosition.x + posMouse.x < 0) {
            //Debug.Log("OUII");
            transform.localScale = new Vector3(2, -2, 0);
            //transform.rotation = Quaternion.Inverse(target.rotation);
            }
        else { transform.localScale = new Vector3(2, 2, 0); }
    }





}
