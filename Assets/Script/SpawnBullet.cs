using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public string BulletName = null;
    BulletPool bulletPool;

    private void Start() {
        bulletPool = BulletPool.Instance;    
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space)){
            bulletPool.SpawnFromPool(BulletName,transform.position);
        }
    }
}
