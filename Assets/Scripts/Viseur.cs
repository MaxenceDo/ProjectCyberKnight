using UnityEngine;
using System.Collections;

public class Viseur : MonoBehaviour
{

	Vector3 posMouse;


	// Update is called once per frame
	void FixedUpdate()
	{
		posMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		posMouse.z = 0;
		gameObject.transform.position = posMouse;
	}
}