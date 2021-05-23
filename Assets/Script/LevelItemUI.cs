using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelItemUI : MonoBehaviour
{
    JsonManager jsonManager;
    public int LvDamage;
    public int LvSpeed;
	public int LvFireRate;
    public int LvBulletNum;
    public int LvBulletSpeed;
	public int LvPlayerScale;
    public int LP;

    public Text TextLvDamage;
    public Text TextLvSpeed;
	public Text TextLvFireRate;
    public Text TextLvBulletNum;
    public Text TextLvBulletSpeed;
	public Text TextLvPlayerScale;
    public Text TextLP;

    private void Start() {
        jsonManager = FindObjectOfType<JsonManager>().GetComponent<JsonManager>();
        jsonManager.LoadSaveJson();

		AssignJson();
    }

    private void Update() {
        UpdateText();
    }

    void AssignJson(){
        LvDamage = jsonManager.playerData.LvDamage;
		LvSpeed = jsonManager.playerData.LvSpeed;
        LvFireRate = jsonManager.playerData.LvFireRate;
        LvBulletNum = jsonManager.playerData.LvBulletNum;
        LvBulletSpeed = jsonManager.playerData.LvBulletSpeed;
        LvPlayerScale = jsonManager.playerData.LvPlayerScale;
        LP = jsonManager.playerData.LP;
    }

    void UpdateText(){
        TextLvDamage.text = "LV " + LvDamage;
        TextLvSpeed.text = "LV " + LvSpeed;
        TextLvFireRate.text = "LV " + LvFireRate;
        TextLvBulletNum.text = "LV " + LvBulletNum;
        TextLvBulletSpeed.text = "LV " + LvBulletSpeed;
        TextLvPlayerScale.text = "LV " + LvPlayerScale;
        TextLP.text = "LP " + LP;

        if(LvSpeed >= 9){
            TextLvSpeed.text = "LV Max";
        }
        if(LvFireRate >= 8){
            TextLvFireRate.text = "LV Max";
        }
        if(LvBulletNum >= 3){
            TextLvBulletNum.text = "LV Max";
        }
        if(LvBulletSpeed >= 6){
            TextLvBulletSpeed.text = "LV Max";
        }
        if(LvPlayerScale >= 10){
            TextLvPlayerScale.text = "LV Max";
        }
    }
}
