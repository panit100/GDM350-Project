using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float hitPoint = 1.0f;
    public bool shield = false;
    public bool isDead = false;

    public virtual void TakeDamage(float damage){
        hitPoint -= damage;

        if(hitPoint <= 0){
            if(!isDead){
                isDead = true;
                Die();
            }
        }
    } 

    public virtual void Die(){
        
    }


}
