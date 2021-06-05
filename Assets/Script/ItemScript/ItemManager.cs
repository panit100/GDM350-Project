using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using RandomDLL;

public class ItemManager : MonoBehaviour
{
    RandomItem randomItem1;
    public BaseItem[] item;
    int randomItem;

    //CondfigFile
    public string ConfFileName = "ConfigData.csv";
    Dictionary<string, Item> Items = new Dictionary<string, Item>();

    private void Awake() {
        
        ReadData();

        RandomNumberGen.Initialize();
        randomItem1 = new RandomItem(item.Length-1);

    }
    private void ReadData()
    {
        StreamReader input = null;
        string path = Application.dataPath + "/StreamingAssets";
        try
        {
            input = File.OpenText(Path.Combine(path,
                                        ConfFileName));
            string name = input.ReadLine();
            string values = input.ReadLine();
            while (values != null)
            {
                AssignData(values);
                values = input.ReadLine();
            }
        }
        catch (Exception ex) { Debug.Log(ex.Message); }
        finally { if (input != null) input.Close(); }
    }
    void AssignData(string values)
    {
        string[] data = values.Split(',');
        float no = int.Parse(data[0]);
        string itemName = data[1];
        float speed = float.Parse(data[2]);
        float damage = float.Parse(data[3]);
        float fireRate = float.Parse(data[4]);
        int bulletNum = int.Parse(data[5]);
        float bulletSpeed = float.Parse(data[6]);
        float scale = float.Parse(data[7]);
        bool shield = bool.Parse(data[8]);
        int dropRate = int.Parse(data[9]);
        
        Item item = new Item(speed,damage,fireRate,bulletNum,bulletSpeed,scale,shield,dropRate);
        Items.Add(itemName, item);
    }

    public void DropItem(Transform transform){
        //แก้
        RandomDropItem();

        string className = item[randomItem].GetType().Name;
        float speed = 0;
        float damage = 0;
        float fireRate = 0;
        int bulletNum = 0;
        float bulletSpeed = 0;
        float scale = 0;
        bool shield = false;
        int dropRate = 0;
            Item ItemData = new Item(speed,damage,fireRate,bulletNum,bulletSpeed,scale,shield,dropRate);
            switch(className){
                case "ItemSpeed" :
                    ItemData = Items["ItemSpeed"];
                    break;
                case "ItemDamage" :
                    ItemData = Items["ItemDamage"];
                    break;
                case "ItemFireRate" :
                    ItemData = Items["ItemFireRate"];
                    break;
                case "ItemBulletNum" :
                    ItemData = Items["ItemBulletNum"];
                    break;
                case "ItemBulletSpeed" :
                    ItemData = Items["ItemBulletSpeed"];
                    break;
                case "ItemShield" :
                    ItemData = Items["ItemShield"];
                    break;
                case "ItemScale" :
                    ItemData = Items["ItemScale"];
                    break;
                
                default:
                    break;
            }

        item[randomItem].speed = ItemData.Speed;
        item[randomItem].damage = ItemData.Damage;
        item[randomItem].fireRate = ItemData.FireRate;
        item[randomItem].bulletNum = ItemData.BulletNum;
        item[randomItem].bulletSpeed = ItemData.BulletSpeed;
        item[randomItem].scale = ItemData.Scale;
        item[randomItem].shield = ItemData.Shiled;

        int randomDrop = UnityEngine.Random.Range(0,100);
        if(randomDrop <= ItemData.DropRate){
            BaseItem newitem = Instantiate(item[randomItem],transform.position,item[randomItem].transform.rotation) as BaseItem;
            newitem.gameObject.name = newitem.gameObject.name.Replace("(Clone)","");
        }

        
    
    }

    void RandomDropItem(){
        RandomNumberGen.Initialize();
        randomItem1.Random();
        randomItem = randomItem1.GetItem;
    }
}
