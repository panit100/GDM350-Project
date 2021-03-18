using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int EnemySetIndex;
    public bool BossObject = false;

    [Header("EnemySetting")]
    float Hp = 1f;
    float moveSpeed = 5f;

    Vector2 nextPosition;
    EnemyManager enemyManager;
    Player player;

    private void Awake() {
        enemyManager = FindObjectOfType<EnemyManager>();
    }

    private void Start() {
        player = FindObjectOfType<Player>().GetComponent<Player>();
    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position,nextPosition,moveSpeed);
        transform.rotation = Quaternion.identity;
        
        if(BossObject){
            print(Hp);
        }

        CheckWayPoint();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            //Do Damage to player
            player.TakeDamage();
            if(gameObject.tag != "Boss"){
                DestroyEnemy();
            }
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
        //Drop Item
        ItemManager itemManager = FindObjectOfType<ItemManager>().GetComponent<ItemManager>();
        itemManager.DropItem(transform);

        Destroy(gameObject);
    }

    public float MoveSpeed{
        set{ moveSpeed = value;}
    }
    public float HitPoint{
        set{ Hp = value;}
    }

    void CheckWayPoint(){
        foreach(Transform n in enemyManager.enemySets[EnemySetIndex].PattenPoint){
            if(transform.position == n.position){
                int currentPoint = enemyManager.enemySets[EnemySetIndex].PattenPoint.IndexOf(n);

                if(currentPoint == enemyManager.enemySets[EnemySetIndex].PattenPoint.Count - 1){
                    return;
                }
                SetMoveDirection(enemyManager.enemySets[EnemySetIndex].PattenPoint[++currentPoint].position);
            }
        }
    }

    public void TakeDamage(float damage){
        Hp -= damage;

        if(Hp <= 0){
            DestroyEnemy();
        }
    }
    
}
