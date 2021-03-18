﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBulletNum : BaseItem
{
    public override void Ability()
    {
        Player player = FindObjectOfType<Player>().GetComponent<Player>();
        player.BulletNum += bulletNum;
        base.Ability();
    }
}