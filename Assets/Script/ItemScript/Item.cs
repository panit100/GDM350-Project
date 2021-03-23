using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string name;
    float increaseSpeed = 0f;
    float increaseDamage = 0f;
    float increaseFireRate = 0f;
    int increaseBulletNum = 0;
    float increaseBulletSpeed = 0f;
    float decreaseScale = 0f;
    bool shield = false;
    int dropRate = 0;

    public Item(float IncreaseSpeed,float IncreaseDamage,float IncreaseFireRate,int IncreaseBulletNum,float IncreaseBulletSpeed,float DecreaseScale,bool Shield,int newDropRate){
        increaseSpeed = IncreaseSpeed;
        increaseDamage = IncreaseDamage;
        increaseFireRate = IncreaseFireRate;
        increaseBulletNum = IncreaseBulletNum;
        increaseBulletSpeed = IncreaseBulletSpeed;
        decreaseScale = DecreaseScale;
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
    public float FireRate{
        get{
            return increaseFireRate;
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
    public float Scale{
        get{
            return decreaseScale;
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
