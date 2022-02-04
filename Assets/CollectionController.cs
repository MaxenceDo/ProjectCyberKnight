using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item{
    public string name;
    
    public Sprite itemImage;
    public string description;
}

public class CollectionController : MonoBehaviour
{
    // Start is called before the first frame update
    public Item item;
    public int healthChange;
    public float moveSpeed;
    public int damage;
    public float attackSpeed;
    public int price;
    public Sprite itemSprite;
    void Start()
    {
        Destroy(GetComponent<BoxCollider2D>());
        gameObject.AddComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player") && Player.money>=price){
            Player.healthChange = Player.IncreaseMaxHealth(healthChange);
            Player.updateMoney(price);
            CharacterController.updateSpeed(moveSpeed);
            Weapon.updateDamage(damage);
            print(Weapon.Damage);
            //GameMaster.ChangeDamage(moveSpeed);
            //GameMaster.ChangeAttackSpeed(attackSpeed);
            Destroy(gameObject);
        }
    }

}
