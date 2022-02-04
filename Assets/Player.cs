using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int Damage = 10;
    public float camShakeAmt = 0.1f;
    public float camShakeLength = 0.1f;
    public static int healthChange;

    public static int money = 300;
    public static int Money {get => money; set => money = value;}

    CameraShake camShake;

    [System.Serializable]
    public class PlayerStats
    {
        public int maxHealth = 100;

        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public void Init()
        {
            curHealth = maxHealth;
        }

        public void UpdateMaxHealth(int health){
            maxHealth += health;
        }
    }

    public PlayerStats stats = new PlayerStats();

    public int GoOut = -15;

    public static int IncreaseMaxHealth(int Health){
        return Health;
    }

    public static void updateMoney(int minusMoney){
        money -= minusMoney;
    }


    [SerializeField]
    private StatusIndicator statusIndicator;
    void Start()
    {
        camShake = GameMaster.gm.GetComponent<CameraShake>();
        stats.Init();
        if(statusIndicator == null)
        {
            Debug.LogError("oui");
        }
        else
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }
    }

    void Update()
    {
        //Debug.Log(transform.position.x);
        if (transform.position.x <= GoOut)
            DamagePlayer(9999999);
        stats.UpdateMaxHealth(healthChange);
        healthChange=0;
        

    }

    public void DamagePlayer (int damage)
    {
        stats.curHealth -= damage;
        if (stats.curHealth <= 0)
        {
            GameMaster.KillPlayer(this);
        }
        statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Tir")) {
            DamagePlayer(Damage);
            camShake.Shake(camShakeAmt, camShakeLength);
        }
        //Destroy(gameObject);
    }


}
