using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : MonoBehaviour
{
    public GameObject Projectil;
    
 
    public int force = 10;
    public float shotTime;
    public int Damage = 10;
    private float startTime;
    private float elapsedTime;
    Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

    }

    void Awake()
    {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No Eject ??");
        }
    }

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

        if (elapsedTime >= shotTime)
        {
            startTime = Time.time;
            GameObject Tir = Instantiate(Projectil, firePoint.position, Projectil.transform.rotation) as GameObject;
            Tir.GetComponent<Rigidbody2D>().velocity = firePoint.TransformDirection(new Vector2(1, 0) * force);
            Destroy(Tir, 2f);
        }
        
        


        
   
    }


}
