using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpeed : BaseItem
{
    public override void Ability()
    {
        Player player = FindObjectOfType<Player>().GetComponent<Player>();
        LevelItemUI levelItemUI = FindObjectOfType<LevelItemUI>().GetComponent<LevelItemUI>();
        levelItemUI.LvSpeed++;
        player.Speed += speed;
        base.Ability();
    }
}
