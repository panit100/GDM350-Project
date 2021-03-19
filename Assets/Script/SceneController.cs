using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public void ChangeScene(int nextScene){
        SceneManager.LoadScene(nextScene);
    }

    public void Restart(){
        SceneManager.LoadScene(1);
    }

    //Continue
    //PlayerPref key int ContinueScene
    public void LoadScene(){
        if(PlayerPrefs.HasKey("ContinueScene")){
            SceneManager.LoadScene(PlayerPrefs.GetInt("ContinueScene"));
        }

        
    }
}
