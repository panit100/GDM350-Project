using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Damage;
    Vector2 nextPosition;
    float moveSpeed = 5f;
    public int EnemySetIndex;
    EnemyController enemyController;
    private void Awake() {
        enemyController = FindObjectOfType<EnemyController>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,nextPosition,moveSpeed);
        transform.rotation = Quaternion.identity;
        
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
        Invoke("DestroyEnemy",1.5f);
    }

    private void OnBecameVisible() {
        CancelInvoke();
    }

    public void DestroyEnemy(){
        Destroy(gameObject);
    }

    public float MoveSpeed{
        set{ moveSpeed = value;}
    }

    void CheckWayPoint(){
        foreach(Transform n in enemyController.enemySets[EnemySetIndex].PattenPoint){
            if(transform.position == n.position){
                
                int currentPoint = enemyController.enemySets[EnemySetIndex].PattenPoint.IndexOf(n);
                print(currentPoint);
                if(currentPoint == enemyController.enemySets[EnemySetIndex].PattenPoint.Count - 1){
                    return;
                }
                SetMoveDirection(enemyController.enemySets[EnemySetIndex].PattenPoint[++currentPoint].position);
            }
        }

        
    }
    
}
