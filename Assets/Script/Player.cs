using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool alive = true;
    public bool shield = false;
    float spacialTime = 5f;

    [Header("Player Stat")]
    float damage = 5f;
    float speed = 10f;

    [Header("Bullet Stat")]

    [Range(1,3)]
    int bulletNum = 1; //จำนวนกระสุนที่ออกพร้อมกัน 1-3
    float bulletSpeed = 50f; //base speed 50  Max 200;

    private void Update() {
        SpacialTime();
    }

    public void TakeDamage(){
        if(spacialTime > 0){
            return;
        }

        if(shield){
            shield = false;
            spacialTime = 3f;
        }else{
            alive = false;
        }
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
        }

        get {
            return speed;
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

            if(bulletSpeed > 200){
                bulletSpeed = 200;
            }

        }

        get {
            return bulletSpeed;
        }
    }
    public bool Alive{
        set{
            alive = value;
        }

        get {
            return alive;
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
        if(spacialTime >= 0){
            GetComponent<CircleCollider2D>().isTrigger = true;
            spacialTime -= Time.deltaTime;
            //player animation
        }else{
            GetComponent<CircleCollider2D>().isTrigger = false;
        }
    }

    
}
