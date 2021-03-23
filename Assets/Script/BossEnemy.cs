using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
    Manager manager;

    private void Awake() {
        
        manager = FindObjectOfType<Manager>().GetComponent<Manager>();
    }

    public override void Die()
    {
        manager.isBossDie();
        base.Die();
    }
}
