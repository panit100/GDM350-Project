using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDamage : BaseItem
{
    public override void Ability()
    {
        Player player = FindObjectOfType<Player>().GetComponent<Player>();
        player.Damage += damage;
        LevelItemUI levelItemUI = FindObjectOfType<LevelItemUI>().GetComponent<LevelItemUI>();
        levelItemUI.LvDamage++;
        base.Ability();
    }
}
