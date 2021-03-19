using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShield : BaseItem
{
    public override void Ability()
    {
        Player player = FindObjectOfType<Player>().GetComponent<Player>();
        player.Shield = shield;
        player.shieldSprite.SetActive(true);
        base.Ability();
    }
}
