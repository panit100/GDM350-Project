using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    Vector2 moveDirection;
    Player player;

    private void Start() {
        player = FindObjectOfType<Player>().GetComponent<Player>();
        damage = player.Damage;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Entity hitEntity = other.gameObject.GetComponent<Entity>();

        if(hitEntity == null)
            return;
        if(hitEntity is Player && ownedBy is Player)
            return;
        if(hitEntity is Enemy && ownedBy is Enemy)
            return;

        hitEntity.TakeDamage(damage);
        DestroyBullet();
    }

    public override void DestroyBullet(){
        gameObject.SetActive(false);
    }

    // public void SetMoveDirection(Vector2 dir){
    //     moveDirection = dir;
    // }

    

     

    // public IEnumerator DestroyBulletOverSeconds(float time){
    //     yield return new WaitForSeconds(time);
    //     DestroyBullet();
    // }

    public float MoveSpeed{
        set{ speed = value;}
    }
}
