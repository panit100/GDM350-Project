﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [Header("Score")]
    int Score1 = 0;
    int Score2 = 0;
    int Score3 = 0;

    [Header("UI")]
    public Button restart;
    public Text ShowText;
    public GameObject PauseMenu;

    LevelItemUI levelItemUI;
    JsonManager jsonManager;
    int sceneIndex;
    Player player;

    public GameObject PlayerPrefab;
    
    private void Start() {
        Time.timeScale = 1f;

        
        jsonManager = FindObjectOfType<JsonManager>().GetComponent<JsonManager>();
        levelItemUI = FindObjectOfType<LevelItemUI>().GetComponent<LevelItemUI>();
        

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update() {

        if(Input.GetKeyDown(KeyCode.Escape)){
            if(Time.timeScale == 0){
                Time.timeScale = 1;
                PauseMenu.SetActive(false);
            }else if(Time.timeScale == 1){
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
            }
        }
    }

    private void FixedUpdate() {
        player = FindObjectOfType<Player>().GetComponent<Player>();
    }

//EventHandling
    public void isBossDie(){

        StartCoroutine(InvokeSave());
        print("Do something Before Change Scene");
        ShowText.gameObject.SetActive(true);
        PlayerPrefs.SetInt("ContinueScene",sceneIndex+1);
        PlayerPrefs.Save();
        StartCoroutine(GoNextStage());
    }

//EventHandling
    public void isPlayerDead(){
        if(player.isDead && levelItemUI.LP <= 1){
            Time.timeScale = 0f;
            //Save Score
            SavingScore();

            //delete save
            PlayerPrefs.DeleteKey("ContinueScene");
            
            //Show UI
            restart.gameObject.SetActive(true);

            if(player != null){
                Destroy(player.gameObject);
            }
        }else{
            Destroy(player.gameObject);
            levelItemUI.LP -= 1;
            jsonManager.CreateJson();
            GameObject Player = Instantiate(PlayerPrefab);
        }
    }

    public IEnumerator GoNextStage(){
        yield return new WaitForSeconds(5f);

        if(sceneIndex == SceneManager.sceneCountInBuildSettings-1){
                    //End game

                    //Save Score
                    SavingScore();
                    
                    //Delete CheckPoint
                    PlayerPrefs.DeleteKey("ContinueScene");
                    print("END GAME");
                    
        }else{
                    //save;
                    //PlayerPref key int ContinueScene
                
                    SceneManager.LoadScene(sceneIndex+1);
                    print("Change Scene");
        }
    }

    public IEnumerator InvokeSave(){
        yield return new WaitForSeconds(2.5f);
        jsonManager.CreateJson();
    }


    void SavingScore(){
        LoadScore();
        UpdateScore();
    }

    void LoadScore(){
        Score1 = PlayerPrefs.GetInt("Score1",0);
        Score2 = PlayerPrefs.GetInt("Score2",0);
        Score3 = PlayerPrefs.GetInt("Score3",0); 
    }
    void UpdateScore(){
        int LastRoundScore = levelItemUI.Score;

        if(LastRoundScore > Score1){
            PlayerPrefs.SetInt("Score3",Score2);
            PlayerPrefs.SetInt("Score2",Score1);
            PlayerPrefs.SetInt("Score1",LastRoundScore);
            return;
        }else if(LastRoundScore > Score2){
            PlayerPrefs.SetInt("Score3",Score2);
            PlayerPrefs.SetInt("Score2",LastRoundScore);
            return;
        }else if(LastRoundScore > Score3){
            PlayerPrefs.SetInt("Score3",LastRoundScore);
        }
    }
    
}
