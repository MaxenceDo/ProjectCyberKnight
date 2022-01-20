using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{


 

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Mur"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Untagged"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ennemi"))
        {
            Destroy(gameObject);
        }
        //if (collision.gameObject.CompareTag("Ennemi"))
        //{




        //    Vector2 TirPosition = new Vector2(transform.position.x, transform.position.y);
        //    Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        //    RaycastHit2D hit = Physics2D.Raycast(firePointPosition, TirPosition - firePointPosition, 100, whatToHit);


        //    Debug.DrawLine(firePointPosition, (TirPosition - firePointPosition) * 100);
        //    if (hit.collider != null)
        //    {
        //        //Debug.DrawLine(firePointPosition, hit.point, Color.red);

        //        Player player = hit.collider.GetComponent<Player>();
        //        if (player != null)
        //        {
        //            Debug.DrawLine(firePointPosition, hit.point, Color.red);
        //            col2DHit.isTrigger = true;
        //            //Debug.Log("We Hit " + hit.collider.name + "and did" + Damage + "Damage");
        //        }
        //        col2DHit.isTrigger = false;
        //    }




        //}




        //Destroy(gameObject);
    }
}
