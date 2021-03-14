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
        public float spawnTime;
        public bool isRandomPoint;
        public List<Transform> wayPoint;
    }
    [System.Serializable]
    public class WayPoint{
        public string wayPointName;
        public List<Transform> randomPoint;
    }
    private enum EnemySpawnStep{
        StartDelay,StartSpawn,Waiting
    }
    EnemyPool enemyPool;
    EnemySpawnStep enemySpawnStep;

    public float Timer = 0;

    [Header("WayPoint")]
    public WayPoint[] wayPoints;


    [Header("SpawnLoopStep")]
    public List<EnemySet> enemySets;
    public float delayLoopTimer = 0;
    public float delayLoopTime = 3; //ตั้งความเร็วการเกิดรอบต่อไป


    int randomStartPoint;
    int randomNextPosition;
    bool isRandom = false;

    private void Start() {
        enemyPool = EnemyPool.Instance;
        
    }
    void Update()
    {
        Timer += Time.deltaTime;
        foreach(EnemySet enemy in enemySets){
            Spawn(enemy,enemy.spawnTime);
        }

        
    }

    void SpawnEnemy(EnemySet enemySet){
        GameObject enemy = Instantiate(enemySet.enemyPrefab.gameObject,wayPoints[0].randomPoint[randomStartPoint]);
        enemy.GetComponent<Enemy>().MoveSpeed = enemySet.enemySpeed;
        enemy.GetComponent<Enemy>().SetMoveDirection(wayPoints[1].randomPoint[randomNextPosition].position);

        enemySet.enemyCount--;
    }

    
    void UpdateSpawnStep(EnemySet enemySet){
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
            SpawnEnemy(enemySet);

            delayLoopTimer = delayLoopTime;
            enemySpawnStep = EnemySpawnStep.Waiting;
        }

        if(enemySpawnStep == EnemySpawnStep.Waiting){
            if(delayLoopTimer > 0f){
                enemySpawnStep = EnemySpawnStep.StartDelay;
            }
        }
    }

    void Spawn(EnemySet enemySet,float time){
        if(Timer > time){
            if(!isRandom){
                randomStartPoint = Random.Range(0,wayPoints[0].randomPoint.Count);
                randomNextPosition = Random.Range(0,wayPoints[0].randomPoint.Count);
                isRandom = !isRandom;
            }

            if(enemySet.enemyCount > 0){
                UpdateSpawnStep(enemySet);
                
            }else if(enemySet.enemyCount == 0){
                isRandom = !isRandom;
                enemySet.enemyCount--;
            }
        }
        
    }

    void RandomWayPoint(){

    }
}
