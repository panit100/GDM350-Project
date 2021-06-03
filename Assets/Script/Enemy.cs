using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    float fireRate = 0.1f;

    float damageWhenHit = 10000f;

    Player player;
    EnemyWeapon[] weapons;
    LevelItemUI levelItemUI;

    public int gettingScore;


    private void Start() {
        player = FindObjectOfType<Player>().GetComponent<Player>();
        levelItemUI = FindObjectOfType<LevelItemUI>().GetComponent<LevelItemUI>();

        weapons = GetComponentsInChildren<EnemyWeapon>();

        AddDieListener();
    }

    public void Fire()
    {
        if (weapons.Length == 0) return;
        foreach(EnemyWeapon weapon in weapons)
        {
            weapon.fire();
        }
    }

    public void FireProjectile()
    {
        if (weapons.Length == 0) return;
        foreach(EnemyWeapon weapon in weapons)
        {
            weapon.fireProjectile();
        }
    }

    public void FireEnemyUp()
    {
        if (weapons.Length == 0) return;
        foreach(EnemyWeapon weapon in weapons)
        {
            weapon.fireEnemyUp();
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
        levelItemUI.Score += gettingScore;
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
