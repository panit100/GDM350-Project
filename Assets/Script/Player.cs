using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Entity
{
    JsonManager jsonManager;
    public GameObject shieldSprite;

    [Header("Player Stat")]
    public float damage = 5f;
    public float speed = 10f;
    public float fireRate = 1f;
    float UndyingTime = 5f;

    [Header("Bullet Stat")]

    [Range(1,3)]
    public int bulletNum = 1; //จำนวนกระสุนที่ออกพร้อมกัน 1-3
    public float bulletSpeed = 50f; //base speed 50  Max 200;

    private void Start() {
        jsonManager = FindObjectOfType<JsonManager>().GetComponent<JsonManager>();
        jsonManager.LoadSaveJson();

        shield = true;

        
		AssignJson();
    }

    private void Update() {
        SpacialTime();
    }

    public override void TakeDamage(float damage){
        if(UndyingTime > 0){
            return;
        }

        if(shield){
            shield = false;
            shieldSprite.SetActive(false);
            UndyingTime = 3f;
            return;
        }

        base.TakeDamage(damage);
    }

    public override void Die()
    {
        Manager manager = FindObjectOfType<Manager>().GetComponent<Manager>();
        manager.isPlayerDead();
    }

    public float Damage{
        set{
            damage = value;
        }
        
        get {
            return damage;
        }
    }
    public float Speed{
        set{
            speed = value;

            if(speed > 30){
                speed = 30;
            }
        }

        get {
            return speed;
        }
    }
    public float FireRate{
        set{
            fireRate = value;

            if(fireRate < 0.1f){
                fireRate = 0.1f;
            }
        }

        get{
            return fireRate;
        }
    }

    public int BulletNum{
        set{
            bulletNum = value;

            if(bulletNum > 3){
                bulletNum = 3;
            }
        }

        get {
            return bulletNum;
        }
    }
    public float BulletSpeed{
        set{
            bulletSpeed = value;

            if(bulletSpeed > 70){
                bulletSpeed = 70;
            }
        }

        get {
            return bulletSpeed;
        }
    }
    
    public bool Shield{
        set{
            shield = value;
        }

        get {
            return shield;
        }
    }

    void SpacialTime(){
        if(UndyingTime >= 0){
            GetComponent<CircleCollider2D>().isTrigger = true;
            UndyingTime -= Time.deltaTime;
            //player animation
        }else{
            GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }

    void AssignJson(){
        Damage = jsonManager.playerData.damage;
		Speed = jsonManager.playerData.speed;
        BulletNum = jsonManager.playerData.bulletNum;
        BulletSpeed = jsonManager.playerData.bulletSpeed;
	}
}
