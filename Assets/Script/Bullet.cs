﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float damage;
    Vector2 moveDirection;
    float moveSpeed = 5f;

    void FixedUpdate()
    {
        damage = Player.Damage;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            DestroyBullet();
        }
    }

    public void SetMoveDirection(Vector2 dir){
        moveDirection = dir;
    }

    private void OnBecameInvisible() {
        DestroyBullet();
    }

    private void OnBecameVisible() {
        CancelInvoke();
    }

    void DestroyBullet(){
        gameObject.SetActive(false);
    }

    public float MoveSpeed{
        set{ moveSpeed = value;}
    }
}
