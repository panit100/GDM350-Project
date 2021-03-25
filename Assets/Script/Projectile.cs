using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float damage;
    public Entity ownedBy;


    private void FixedUpdate() {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
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
        Destroy(gameObject);
    }

    private void OnBecameInvisible() {
        DestroyBullet();
    }

    private void OnBecameVisible() {
        CancelInvoke();
    }

    public virtual void DestroyBullet(){
        Destroy(gameObject);
    }
}
