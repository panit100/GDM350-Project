using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    BulletPool bulletPool;

    private void Start() {
        bulletPool = BulletPool.Instance;    
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space)){
            bulletPool.SpawnFromPool("Bullet",transform.position);
        }
    }
}
