using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 moveDirection;
    float moveSpeed = 5f;

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy"){
            other.gameObject.GetComponent<Enemy>().DestroyEnemy();
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
