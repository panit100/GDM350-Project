using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    public class SpawnEnemy{
        public Enemy enemy;
        public float spawnTime;
        public float waitBeforeSpawn;
        public int amount;
    }

    public SpawnEnemy[] spawnEnemies;

    void Start(){
        StartCoroutine(SpawnEnemies());
    }

    public IEnumerator SpawnEnemies(){
        foreach(SpawnEnemy n in spawnEnemies){
            yield return new WaitForSeconds(n.spawnTime);
            StartCoroutine(Spawn(n.enemy,n.waitBeforeSpawn,n.amount));
        }
    }
    
    public IEnumerator Spawn(Enemy enemy,float wait,int amount){
        for(int i = 0;i < amount; i++){
            yield return new WaitForSeconds(wait);
            Instantiate(enemy);
        }
    }

}
