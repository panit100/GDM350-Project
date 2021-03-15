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
        public float delayTime;
        public bool isRandomPoint;
        public List<Transform> PattenPoint;
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

    int currentEnemy = 0;

    private void Awake() {
        enemyPool = EnemyPool.Instance;
    }
    void FixedUpdate()
    {
        foreach(EnemySet enemy in enemySets){
            Spawn();
        }
    }

    void SpawnEnemy(EnemySet enemySet){
        GameObject enemy = Instantiate(enemySet.enemyPrefab.gameObject,enemySet.PattenPoint[0]);
        enemy.GetComponent<Enemy>().EnemySetIndex = enemySets.IndexOf(enemySet);
        enemy.GetComponent<Enemy>().MoveSpeed = enemySet.enemySpeed;
        enemy.GetComponent<Enemy>().SetMoveDirection(enemySet.PattenPoint[1].position);

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

    void Spawn(){
        if(currentEnemy > enemySets.Count - 1){
            //Boss
            return;
        }

        if(Timer >= enemySets[currentEnemy].delayTime){
            if(enemySets[currentEnemy].enemyCount > 0){
                UpdateSpawnStep(enemySets[currentEnemy]);
            }
        }

        if(enemySets[currentEnemy].enemyCount <= 0 && GameObject.FindObjectOfType<Enemy>() == null){
            Timer = 0;
            currentEnemy++;
        }

        Timer += Time.deltaTime;
    }
    
    void RandomWayPoint(){
        //Not now
    }
}
