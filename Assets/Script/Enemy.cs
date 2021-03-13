using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Damage;
    Vector2 nextPosition;
    float moveSpeed = 5f;
    

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,nextPosition,moveSpeed);
        CheckWayPoint();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            //Do Damage to player
            Destroy(gameObject);
        }
    }

    public void SetMoveDirection(Vector2 dir){
        nextPosition = dir;
    }
    private void OnBecameInvisible() {
        Invoke("DestroyBullet",1.5f);
    }

    private void OnBecameVisible() {
        CancelInvoke();
    }

    public void DestroyBullet(){
        Destroy(gameObject);
    }

    public float MoveSpeed{
        set{ moveSpeed = value;}
    }

    void CheckWayPoint(){
        EnemyController enemyController = FindObjectOfType<EnemyController>();
        
        if(transform.position.x == enemyController.wayPoint1[0].position.x){
            int randomNextPosition = Random.Range(0,enemyController.wayPoint1.Length);
            SetMoveDirection(enemyController.wayPoint2[randomNextPosition].position);
        }
        
        if(transform.position.x == enemyController.wayPoint2[0].position.x){
            int randomNextPosition = Random.Range(0,enemyController.wayPoint1.Length);
            SetMoveDirection(enemyController.wayPoint3[randomNextPosition].position);
        }

        if(transform.position.x == enemyController.wayPoint3[0].position.x){
            int randomNextPosition = Random.Range(0,enemyController.wayPoint1.Length);
            SetMoveDirection(enemyController.endPoint[randomNextPosition].position);
        }

        // if(transform.position.x == enemyController.wayPoint2[0].position.x){
        //     int randPoint = Random.Range(0,1);
        //     int randomNextPosition = Random.Range(0,enemyController.wayPoint1.Length);
        //     switch(randPoint){
        //         case 0 :
        //             SetMoveDirection(enemyController.wayPoint1[randomNextPosition].position);
        //             break;
        //         case 1 :
        //             SetMoveDirection(enemyController.wayPoint3[randomNextPosition].position);
        //             break;
        //     }
        // }
    }
    
}
