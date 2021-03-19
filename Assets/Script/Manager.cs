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
    JsonManager jsonManager;
    int sceneIndex;
    Player player;
    
    private void Start() {
        Time.timeScale = 1f;

        enemyManager = FindObjectOfType<EnemyManager>().GetComponent<EnemyManager>();
        player = FindObjectOfType<Player>().GetComponent<Player>();
        jsonManager = FindObjectOfType<JsonManager>().GetComponent<JsonManager>();

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(sceneIndex);
    }

    private void Update() {
        isPlayerDie();

        CheckActiveEnemy();
    }


    void CheckActiveEnemy(){
        if(enemyManager.CurrentEnemy == enemyManager.enemySets.Count){
            print("Do something Before Change Scene");
            jsonManager.CreateJson();
            PlayerPrefs.SetInt("ContinueScene",sceneIndex+1);
            PlayerPrefs.Save();
            if(enemyManager.Timer >= 5f){
                if(sceneIndex == SceneManager.sceneCountInBuildSettings-1){
                    //End game
                    PlayerPrefs.DeleteKey("ContinueScene");
                    return;
                }else{
                    //save;
                    //PlayerPref key int ContinueScene
                
                    SceneManager.LoadScene(sceneIndex+1);
                    print("Change Scene");
                }
                
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

            //delete save
            PlayerPrefs.DeleteKey("ContinueScene");
            
            //Show UI
            restart.gameObject.SetActive(true);
        }
    }

    
}
