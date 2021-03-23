using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFireRate : BaseItem
{
    public override void Ability()
    {
        Player player = FindObjectOfType<Player>().GetComponent<Player>();
        Weapon weapon = FindObjectOfType<Weapon>().GetComponent<Weapon>();
        player.FireRate -= fireRate;
        weapon.fireRate -= fireRate;
        base.Ability();
    }
}
