using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour
{
    public GameObject Projectil;
    public int force = 10;
    public float shotTime;

    private float startTime;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.E))
        //{
        //GameObject Tir = Instantiate(Projectil, transform.position, Quaternion.identity) as GameObject;
        //  Tir.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(1, 0) * force);
        //   Destroy(Tir, 3f);
        //  StartCoroutine(Faire());
        // }

        elapsedTime = Time.time - startTime;

        if ( elapsedTime >= shotTime)
        {
            startTime = Time.time;
            GameObject Tir =  Instantiate(Projectil, transform.position, Projectil.transform.rotation) as GameObject;
            Tir.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(1, 0) * force);
        }


    }

   
}
