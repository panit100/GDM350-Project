using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
                dieEvent.Invoke();
            }
        }
    } 

    public virtual void Die(){
        
    }

    DieEvent dieEvent = new DieEvent();

    public void DieListener(UnityAction listener){
        dieEvent.AddListener(listener);
    }

    public void AddDieListener(){
        DieListener(Die);
    }


}
