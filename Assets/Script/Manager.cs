using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [Header("UI")]
    public Button restart;

    EnemyManager enemyManager;
    int sceneIndex;
    Player player;
    
    private void Start() {
        Time.timeScale = 1f;

        enemyManager = FindObjectOfType<EnemyManager>().GetComponent<EnemyManager>();
        player = FindObjectOfType<Player>().GetComponent<Player>();

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update() {
        isPlayerDie();

        CheckActiveEnemy();
    }


    void CheckActiveEnemy(){
        if(enemyManager.CurrentEnemy == enemyManager.enemySets.Count){
            print("Do something Before Change Scene");
            if(enemyManager.Timer >= 5f){
                if(sceneIndex == SceneManager.sceneCountInBuildSettings){
                    //delete save
                    //End game
                    return;
                }
                //save;
                SceneManager.LoadScene(sceneIndex+1);
                print("Change Scene");
            }
            return;
        }
    }

    void isPlayerDie(){
        if(!player.Alive){
            Time.timeScale = 0f;

            if(player != null){
                Destroy(player.gameObject);
            }
            
            //Show UI
            restart.gameObject.SetActive(true);
            
            //delete save
        }
    }

    public void Restart(){
        SceneManager.LoadScene(sceneIndex);
    }
}
