﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class ItemManager : MonoBehaviour
{
    public BaseItem[] item;

    //CondfigFile
    public string ConfFileName = "ConfigData.csv";
    Dictionary<string, Item> Items = new Dictionary<string, Item>();

    private void Awake() {
        ReadData();
    }
    private void ReadData()
    {
        StreamReader input = null;
        string path = "Assets/StreamingAssets";
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
        int bulletNum = int.Parse(data[4]);
        float bulletSpeed = float.Parse(data[5]);
        bool shield = bool.Parse(data[6]);
        int dropRate = int.Parse(data[7]);
        
        Item item = new Item(speed,damage,bulletNum,bulletSpeed,shield,dropRate);
        Items.Add(itemName, item);
    }

    public void DropItem(Transform transform){
        int randomItem = UnityEngine.Random.Range(0,item.Length);

        string className = item[randomItem].GetType().Name;
        float speed = 0;
        float damage = 0;
        int bulletNum = 0;
        float bulletSpeed = 0;
        bool shield = false;
        int dropRate = 0;
            Item ItemData = new Item(speed,damage,bulletNum,bulletSpeed,shield,dropRate);
            switch(className){
                case "ItemSpeed" :
                    ItemData = Items["ItemSpeed"];
                    break;
                case "ItemDamage" :
                    ItemData = Items["ItemDamage"];
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
                default:
                    break;
            }

        item[randomItem].speed = ItemData.Speed;
        item[randomItem].damage = ItemData.Damage;
        item[randomItem].bulletNum = ItemData.BulletNum;
        item[randomItem].bulletSpeed = ItemData.BulletSpeed;
        item[randomItem].shield = ItemData.Shiled;

        int randomDrop = UnityEngine.Random.Range(0,100);
        if(randomDrop <= ItemData.DropRate){
            Instantiate(item[randomItem],transform.position,transform.rotation);
        }

        
    
    }
}