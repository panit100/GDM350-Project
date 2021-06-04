using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText1;
    public Text ScoreText2;
    public Text ScoreText3;

    void Update(){
        ScoreText1.text = PlayerPrefs.GetInt("Score1",0).ToString();
        ScoreText2.text = PlayerPrefs.GetInt("Score2",0).ToString();
        ScoreText3.text = PlayerPrefs.GetInt("Score3",0).ToString();
    }
}
