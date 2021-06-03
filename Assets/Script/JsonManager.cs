using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//เพิ่ม LifePoint

public class JsonManager : MonoBehaviour
{
    //Json File;
    string json;

    //Class PlayerData
    public class PlayerData{
        public float damage;
        public float speed;
		public float fireRate;
        public int bulletNum; //จำนวนกระสุนที่ออกพร้อมกัน 1-3
        public float bulletSpeed; //base speed 50  Max 200;
		public Vector2 PlayerScale;

		public int LvDamage;
        public int LvSpeed;
		public int LvFireRate;
        public int LvBulletNum;
        public int LvBulletSpeed;
		public int LvPlayerScale;
		public int LP;
		public int Score;
    }
    public PlayerData playerData;
    Player player;
	LevelItemUI levelItemUI;
	

    private void FixedUpdate() {
        if(FindObjectOfType<Player>() != null){
            player = FindObjectOfType<Player>().GetComponent<Player>();
        }

		if(FindObjectOfType<LevelItemUI>() != null){
			levelItemUI = FindObjectOfType<LevelItemUI>().GetComponent<LevelItemUI>();
		}  
    }

    //Json
    //Save
    public void CreateJson(){
		PlayerData NewplayerData = new PlayerData();

		if(FindObjectOfType<Player>() != null){
            NewplayerData.damage = player.Damage;
		    NewplayerData.speed = player.Speed;
			NewplayerData.fireRate = player.fireRate;
		    NewplayerData.bulletNum = player.BulletNum;
		    NewplayerData.bulletSpeed = player.BulletSpeed;
			NewplayerData.PlayerScale = player.transform.localScale;
			NewplayerData.LvDamage = levelItemUI.LvDamage;
			NewplayerData.LvSpeed = levelItemUI.LvSpeed;
			NewplayerData.LvFireRate = levelItemUI.LvFireRate;
			NewplayerData.LvBulletNum = levelItemUI.LvBulletNum;
			NewplayerData.LvBulletSpeed = levelItemUI.LvBulletSpeed;
			NewplayerData.LvPlayerScale = levelItemUI.LvPlayerScale;
			NewplayerData.LP = levelItemUI.LP;
			NewplayerData.Score = levelItemUI.Score;

        }else{
            NewplayerData.damage = playerData.damage;
		    NewplayerData.speed = playerData.speed;
			NewplayerData.fireRate = playerData.fireRate;
		    NewplayerData.bulletNum = playerData.bulletNum;
		    NewplayerData.bulletSpeed = playerData.bulletSpeed;
			NewplayerData.PlayerScale = playerData.PlayerScale;
			NewplayerData.LvDamage = playerData.LvDamage;
			NewplayerData.LvSpeed = playerData.LvSpeed;
			NewplayerData.LvFireRate = playerData.LvFireRate;
			NewplayerData.LvBulletNum = playerData.LvBulletNum;
			NewplayerData.LvBulletSpeed = playerData.LvBulletSpeed;
			NewplayerData.LvPlayerScale = playerData.LvPlayerScale;
			NewplayerData.LP = playerData.LP;
			NewplayerData.Score = playerData.Score;
        }
		

		json = JsonUtility.ToJson(NewplayerData);
		File.WriteAllText(Application.dataPath + "/StreamingAssets" + "/saveFile.json",json);
	}

	//Load
	public void LoadConfigJson(){
		string jsonFromFile = File.ReadAllText(Application.dataPath + "/StreamingAssets" + "/playerConfig.json");

		playerData = JsonUtility.FromJson<PlayerData>(jsonFromFile);
		
	}

    //Load Save
    public void LoadSaveJson(){
		string jsonFromFile = File.ReadAllText(Application.dataPath + "/StreamingAssets" + "/saveFile.json");

		playerData = JsonUtility.FromJson<PlayerData>(jsonFromFile);
		
	}

	
}
