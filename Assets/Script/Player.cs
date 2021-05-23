using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//LifePoint
public class Player : Entity
{
    JsonManager jsonManager;
    public GameObject shieldSprite;

    [Header("Player Stat")]
    public float damage = 5f;   //base damage 5 Max Unlimite
    public float speed = 5f;   //base  speed 5 Max 50
    public float fireRate = 1f; //base 0.5 Max 0.1
    float UndyingTime = 3f;

    [Header("Bullet Stat")]

    [Range(1,3)]
    public int bulletNum = 1; //จำนวนกระสุนที่ออกพร้อมกัน 1-3
    public float bulletSpeed = 50f; //base speed 20  Max 50;

    private void Start() {
        jsonManager = FindObjectOfType<JsonManager>().GetComponent<JsonManager>();
        jsonManager.LoadSaveJson();

        shield = true;

        
		AssignJson();
        Invoke("EnableBoundaires",1);
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

            if(speed > 50){
                speed = 50;
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

            if(bulletSpeed > 50){
                bulletSpeed = 50;
            }
        }

        get {
            return bulletSpeed;
        }
    }

    public Vector2 PlayerScale{
        set{
            transform.localScale = value;
            if(transform.localScale.x < 0.5f){
                transform.localScale = new Vector2(0.5f,0.5f);
            }
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

    void EnableBoundaires(){
        GetComponent<Boundaries>().enabled = true;
    }
    
}
