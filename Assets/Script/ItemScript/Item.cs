using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string name;
    float increaseSpeed = 0f;
    float increaseDamage = 0f;
    int increaseBulletNum = 0;
    float increaseBulletSpeed = 0f;
    bool shield = false;
    int dropRate = 0;

    public Item(float IncreaseSpeed,float IncreaseDamage,int IncreaseBulletNum,float IncreaseBulletSpeed,bool Shield,int newDropRate){
        increaseSpeed = IncreaseSpeed;
        increaseDamage = IncreaseDamage;
        increaseBulletNum = IncreaseBulletNum;
        increaseBulletSpeed = IncreaseBulletSpeed;
        shield = Shield;
        dropRate = newDropRate;
    }

    public float Speed{
        get{
            return increaseSpeed;
        }
    }
    public float Damage{
        get{
            return increaseDamage;
        }
    }
    public int BulletNum{
        get{
            return increaseBulletNum;
        }
    }
    public float BulletSpeed{
        get{
            return increaseBulletSpeed;
        }
    }
    public bool Shiled{
        get{
            return shield;
        }
    }
    public int DropRate{
        get{
            return dropRate;
        }
    }
    
}
