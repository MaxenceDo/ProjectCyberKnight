using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState2
{
    Idle,
    Wander,
    Follow,
    Die,
    Attack
};

public enum EnemyType2
{
    Melee,
    Ranged
};

public class EnemyControllerEnemy2 : MonoBehaviour
{
   
    GameObject player;
    public EnemyState2 currState = EnemyState2.Idle;
    public EnemyType2 enemyType;
    public float range;
    public float speed;
    public float attackRange;
    public float bulletSpeed;
    public float coolDown;
    private bool chooseDir = false;
    private bool dead = false;
    private bool coolDownAttack = false;
    public bool notInRoom = false;
    private Vector3 randomDir;
    public GameObject bulletPrefab;
    Transform firePoint;
    Transform firePoint2;
    Transform arme;

    public GameObject Projectil;
    public int force = 10;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Awake()
    {
        arme = transform.Find("Arme");
        firePoint = arme.transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("No Eject ??");
        }
        firePoint2 = arme.transform.Find("FirePoint2");
        if (firePoint == null)
        {
            Debug.LogError("No Eject ??");
        }
    }
    // Update is called once per frame
    void Update()
    {
        switch(currState)
        {
            //case(EnemyState.Idle):
            //    Idle();
            //break;
            case(EnemyState2.Wander):
                Wander();
            break;
            case(EnemyState2.Follow):
                Follow();
            break;
            case(EnemyState2.Die):
            break;
            case(EnemyState2.Attack):
                Attack();
            break;
        }

        if(!notInRoom)
        {
            if(IsPlayerInRange(range) && currState != EnemyState2.Die)
            {
                currState = EnemyState2.Follow;
            }
            else if(!IsPlayerInRange(range) && currState != EnemyState2.Die)
            {
                currState = EnemyState2.Wander;
            }
            if(Vector3.Distance(transform.position, player.transform.position) <= attackRange)
            {
                currState = EnemyState2.Attack;
            }
        }
        else
        {
            currState = EnemyState2.Idle;
        }
    }

    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    private IEnumerator ChooseDirection()
    {
        chooseDir = true;
        yield return new WaitForSeconds(Random.Range(2f, 8f));
        randomDir = new Vector3(0, 0, Random.Range(0, 360));
        //Quaternion nextRotation = Quaternion.Euler(randomDir);
        //transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        chooseDir = false;
    }

    void Wander()
    {
        if(!chooseDir)
        {
            StartCoroutine(ChooseDirection());
        }

        transform.position += -randomDir * speed * Time.deltaTime;
        if(IsPlayerInRange(range))
        {
            currState = EnemyState2.Follow;
        }
    }

    void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void Attack()
    {
        if(!coolDownAttack)
        {
            switch(enemyType)
            {
                case(EnemyType2.Melee):
                    //GameController.DamagePlayer(1);
                    StartCoroutine(CoolDown());
                break;
                case(EnemyType2.Ranged):
                    //GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
                    //bullet.GetComponent<BulletController>().GetPlayer(player.transform);
                    //bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
                    //bullet.GetComponent<BulletController>().isEnemyBullet = true;

                    GameObject Tir1 = Instantiate(Projectil, firePoint2.position, Projectil.transform.rotation) as GameObject;
                    Tir1.GetComponent<Rigidbody2D>().velocity = firePoint2.TransformDirection(new Vector2(1, 0) * force);
                    Destroy(Tir1, 2f);


                    GameObject Tir = Instantiate(Projectil, firePoint.position, Projectil.transform.rotation) as GameObject;
                    Tir.GetComponent<Rigidbody2D>().velocity = firePoint.TransformDirection(new Vector2(1, 0) * force);
                    Destroy(Tir, 2f);




                    StartCoroutine(CoolDown());
                break;
            }
        }
    }

    private IEnumerator CoolDown()
    {
        coolDownAttack = true;
        yield return new WaitForSeconds(coolDown);
        coolDownAttack = false;
    }

    public void Death()
    {
        RoomController.instance.StartCoroutine(RoomController.instance.RoomCoroutine());
        Destroy(gameObject);
    }
}