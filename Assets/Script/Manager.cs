﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [Header("UI")]
    public Button restart;
    public Text ShowText;

    JsonManager jsonManager;
    int sceneIndex;
    Player player;
    
    private void Start() {
        Time.timeScale = 1f;

        player = FindObjectOfType<Player>().GetComponent<Player>();
        jsonManager = FindObjectOfType<JsonManager>().GetComponent<JsonManager>();

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(sceneIndex);
    }

    public void isBossDie(){

        
            print("Do something Before Change Scene");
            ShowText.gameObject.SetActive(true);
            jsonManager.CreateJson();
            PlayerPrefs.SetInt("ContinueScene",sceneIndex+1);
            PlayerPrefs.Save();
            StartCoroutine(GoNextStage());
    }

    public void isPlayerDead(){
        if(player.isDead){
            Time.timeScale = 0f;

            //delete save
            PlayerPrefs.DeleteKey("ContinueScene");
            
            //Show UI
            restart.gameObject.SetActive(true);

            if(player != null){
                Destroy(player.gameObject);
            }
        }
    }

    public IEnumerator GoNextStage(){
        yield return new WaitForSeconds(5f);

        if(sceneIndex == SceneManager.sceneCountInBuildSettings-1){
                    //End game
                    PlayerPrefs.DeleteKey("ContinueScene");
                    print("END GAME");
        }else{
                    //save;
                    //PlayerPref key int ContinueScene
                
                    SceneManager.LoadScene(sceneIndex+1);
                    print("Change Scene");
        }
    }

    
}
