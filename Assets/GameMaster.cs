using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameMaster : MonoBehaviour
{
    
    public static GameMaster gm;
    


    void Awake()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }


 public static void KillPlayer (Player player)
    {
        Destroy(player.gameObject);
    }

public static void KillEnemy(Enemy enemy)
    {

        Destroy(enemy.gameObject);
        RoomController.instance.StartCoroutine(RoomController.instance.RoomCoroutine());
    }


}
