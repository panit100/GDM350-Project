using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBulletSpeed : BaseItem
{
    public override void Ability()
    {
        Player player = FindObjectOfType<Player>().GetComponent<Player>();
        player.BulletSpeed += bulletSpeed;
        base.Ability();
    }
}
