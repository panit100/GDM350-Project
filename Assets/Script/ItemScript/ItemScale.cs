﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScale : BaseItem
{
    public override void Ability()
    {
        Player player = FindObjectOfType<Player>().GetComponent<Player>();
        LevelItemUI levelItemUI = FindObjectOfType<LevelItemUI>().GetComponent<LevelItemUI>();
        levelItemUI.LvPlayerScale++;
        player.PlayerScale = new Vector2(player.transform.localScale.x-scale,player.transform.localScale.y-scale);
        base.Ability();
    }
}
