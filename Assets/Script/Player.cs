using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player
{
    static bool alive = true;
    static bool shieldOn = true;

    [Header("Player Stat")]
    static float damage = 5f;
    static float speed = 10f;

    [Header("Bullet Stat")]

    [Range(1,3)]
    static int bulletNum = 1; //จำนวนกระสุนที่ออกพร้อมกัน 1-3
    static float bulletSpeed = 0f; //base speed 50;

    public static void TakeDamage(){
        if(shieldOn){
            shieldOn = false;
        }else{
            alive = false;
        }
    }

    public static float Damage{
        set{
            damage = value;
        }
        
        get {
            return damage;
        }
    }
    public static float Speed{
        set{
            speed = value;
        }

        get {
            return speed;
        }
    }
    public static int BulletNum{
        set{
            bulletNum = value;
        }

        get {
            return bulletNum;
        }
    }public static float BulletSpeed{
        set{
            bulletSpeed = value;
        }

        get {
            return bulletSpeed;
        }
    }

    
}
