using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public float fireRate = 0;
    public float cooldown = 0;
    public Entity Parent;
    public Projectile projectile;

    private void Start() {
        if(Parent is Enemy)
        fireRate = Parent.GetComponent<Enemy>().FireRate;
        cooldown = fireRate;
    }

    private void FixedUpdate()
    {
        cooldown -= Time.deltaTime;
    }

    public void fire(){
        if(cooldown > 0)
            return;
        
        Projectile newProjectile = Instantiate(projectile,transform.position,projectile.transform.rotation);
        Vector3 diff = PlayerController.main.transform.position - newProjectile.transform.position;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        newProjectile.transform.eulerAngles = new Vector3(0, 0, rot_z - 90);
        newProjectile.ownedBy = Parent;
        cooldown = fireRate;
        

    }

    public void fireProjectile(){
        if(cooldown > 0)
            return;
        
        Projectile newProjectile = Instantiate(projectile,transform.position,projectile.transform.rotation);
        newProjectile.ownedBy = Parent;
        cooldown = fireRate;
        

    }
}
