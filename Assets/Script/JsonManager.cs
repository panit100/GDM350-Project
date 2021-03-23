using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
    }
    public PlayerData playerData;
    Player player;

    private void Start() {
        if(FindObjectOfType<Player>() != null){
            player = FindObjectOfType<Player>().GetComponent<Player>();
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
        }else{
            NewplayerData.damage = playerData.damage;
		    NewplayerData.speed = playerData.speed;
			NewplayerData.fireRate = playerData.fireRate;
		    NewplayerData.bulletNum = playerData.bulletNum;
		    NewplayerData.bulletSpeed = playerData.bulletSpeed;
			NewplayerData.PlayerScale = playerData.PlayerScale;
        }
		

		json = JsonUtility.ToJson(NewplayerData);
		Debug.Log(json);
		File.WriteAllText(Application.dataPath + "/StreamingAssets" + "/saveFile.json",json);
	}

	//Load
	public void LoadConfigJson(){
		string jsonFromFile = File.ReadAllText(Application.dataPath + "/StreamingAssets" + "/playerConfig.json");

		playerData = JsonUtility.FromJson<PlayerData>(jsonFromFile);
		Debug.Log("damage = " + playerData.damage);
		Debug.Log("speed = " + playerData.speed);
		Debug.Log("fireRate = " + playerData.fireRate);
		Debug.Log("bulletNum = " + playerData.bulletNum);
		Debug.Log("bulletSpeed = " + playerData.bulletSpeed);
		Debug.Log("Scale = " + playerData.PlayerScale);
	}

    //Load Save
    public void LoadSaveJson(){
		string jsonFromFile = File.ReadAllText(Application.dataPath + "/StreamingAssets" + "/saveFile.json");

		playerData = JsonUtility.FromJson<PlayerData>(jsonFromFile);
		Debug.Log("damage = " + playerData.damage);
		Debug.Log("speed = " + playerData.speed);
		Debug.Log("fireRate = " + playerData.fireRate);
		Debug.Log("bulletNum = " + playerData.bulletNum);
		Debug.Log("bulletSpeed = " + playerData.bulletSpeed);
		Debug.Log("Scale = " + playerData.PlayerScale);
	}

	
}
