using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [System.Serializable]
    public class EnemySet{
        public string enemyName;
        public Transform enemyPrefab;
        public float enemySpeed;
        public int enemyCount;
        public float spawnRate;
    }
    private enum EnemySpawnStep{
        StartDelay,StartSpawn,Waiting
    }
    EnemyPool enemyPool;
    EnemySpawnStep enemySpawnStep;

    [Header("WayPoint")]
    public Transform[] startPoint;
    public Transform[] endPoint;
    public Transform[] wayPoint1;
    public Transform[] wayPoint2;
    public Transform[] wayPoint3;


    [Header("SpawnLoopStep")]
    public List<EnemySet> enemySets;
    public float delayLoopTimer = 0;
    public float delayLoopTime = 3; //ตั้งความเร็วการเกิดรอบต่อไป


    int randomStartPoint;
    int randomNextPosition;

    private void Start() {
        enemyPool = EnemyPool.Instance;
        randomStartPoint = Random.Range(0,startPoint.Length);
        randomNextPosition = Random.Range(0,wayPoint1.Length);
    }
    void Update()
    {
        if(enemySets[0].enemyCount > 0){
            UpdateSpawnStep();
        }
    }

    void SpawnEnemy(){
        GameObject enemy = Instantiate(enemySets[0].enemyPrefab.gameObject,startPoint[randomStartPoint]);
        enemy.GetComponent<Enemy>().MoveSpeed = enemySets[0].enemySpeed;
        enemy.GetComponent<Enemy>().SetMoveDirection(wayPoint1[randomNextPosition].position);

        enemySets[0].enemyCount--;
    }

    
    void UpdateSpawnStep(){
        if(enemySpawnStep == EnemySpawnStep.StartDelay){
            if(delayLoopTimer > 0f){
                delayLoopTimer -= Time.deltaTime;
                return;
            }else{
                delayLoopTimer = 0f;
                enemySpawnStep = EnemySpawnStep.StartSpawn;
            }
        }

        if(enemySpawnStep == EnemySpawnStep.StartSpawn){
            SpawnEnemy();

            delayLoopTimer = delayLoopTime;
            enemySpawnStep = EnemySpawnStep.Waiting;
        }

        if(enemySpawnStep == EnemySpawnStep.Waiting){
            if(delayLoopTimer > 0f){
                enemySpawnStep = EnemySpawnStep.StartDelay;
            }
        }
    
        
    }

    
}
