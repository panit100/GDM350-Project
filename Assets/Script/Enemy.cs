using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    float fireRate = 0.1f;

    float damageWhenHit = 10000f;

    Player player;
    EnemyWeapon[] weapons;


    private void Start() {
        player = FindObjectOfType<Player>().GetComponent<Player>();

        weapons = GetComponentsInChildren<EnemyWeapon>();
    }

    public void Fire()
    {
        if (weapons.Length == 0) return;
        foreach(EnemyWeapon weapon in weapons)
        {
            weapon.fire();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            //Do Damage to player
            player.TakeDamage(damageWhenHit);
            if(gameObject.tag != "Boss"){
                DestroyEnemy();
            }
        }
    }

    public void DestroyEnemy(){
        //Drop Item
        ItemManager itemManager = FindObjectOfType<ItemManager>().GetComponent<ItemManager>();
        itemManager.DropItem(transform);

        Destroy(gameObject);
    }

    
    public float HitPoint{
        set{ hitPoint = value;}
    }

    public override void Die()
    {
        DestroyEnemy();
        base.Die();
    }

    public float FireRate{
        set{
            fireRate = value;
        }

        get{
            return fireRate;
        }
    }


    
    
}
