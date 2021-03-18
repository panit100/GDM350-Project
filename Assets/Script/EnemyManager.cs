using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [System.Serializable]
    public class EnemySet{
        public string enemyName;
        public Transform enemyPrefab;
        [Range(1f,10000f)]
        public float Hp; //base speed is 1f
        [Range(0.15f,1f)]
        public float enemySpeed; //base speed is 0.25f
        public int enemyCount;
        public float delayTime;
        //public bool isRandomPoint;
        public List<Transform> PattenPoint;
    }
    
    private enum EnemySpawnStep{
        StartDelay,StartSpawn,Waiting
    }
    EnemyPool enemyPool;
    EnemySpawnStep enemySpawnStep;
    [SerializeField]
    float timer = 0;



    [Header("SpawnLoopStep")]
    public List<EnemySet> enemySets;
    public float delayLoopTimer = 0;
    public float delayLoopTime = 3; //ตั้งความเร็วการเกิดรอบต่อไป

    int currentEnemy = 0;

    private void Awake() 
    {
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
        enemy.GetComponent<Enemy>().HitPoint = enemySet.Hp;

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
        timer += Time.deltaTime;

        if(currentEnemy == enemySets.Count){
            return;
        }

        if(timer >= enemySets[currentEnemy].delayTime){
            if(enemySets[currentEnemy].enemyCount > 0){
                UpdateSpawnStep(enemySets[currentEnemy]);
            }
        }

        if(enemySets[currentEnemy].enemyCount <= 0 && GameObject.FindObjectOfType<Enemy>() == null){
            timer = 0;
            currentEnemy++;
        }
    }
    
    void RandomWayPoint(){
        //Not now
    }

    void CheckActiveEnemy(){

    }

    public int CurrentEnemy{
        get{
            return currentEnemy;
        }
    }

    public float Timer{
        get{
            return timer;
        }
    }
}
