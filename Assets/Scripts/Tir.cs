using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour
{
    public GameObject Projectil;
    public int force = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject Tir = Instantiate(Projectil, transform.position, Quaternion.identity) as GameObject;
            Tir.GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(new Vector2(1, 0) * force);
            Destroy(Tir, 3f);
    
        }
    }
}
