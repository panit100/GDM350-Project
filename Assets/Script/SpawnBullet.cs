using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{

    private enum ShotStep{
        StartDelay,StartShot,WaitDelay,FinishShot
    }

    public string BulletName = null;
    BulletPool bulletPool;
    
    [SerializeField,Range(1,3)]
    int BulletNum = 1; //จำนวนกระสุนที่ออกพร้อมกัน
    public int WayNum = 1;

    public int startAngle = 0,endAngle = 360;
    private const float radius = 1f;
    public float bulletSpeed = 0f;

    

    [Header("ShotStep")]
    ShotStep shotStep;
    public float delayTimer = 0; 
    public float delayTime = 0; //ตั้งความเร็วการยิง

    private void Start() {
        bulletPool = BulletPool.Instance;    
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space)){
            UpdateShotStep();
        }
    }

    void Shot(){
        float angleStep = (startAngle - endAngle) / WayNum;
        float angle = startAngle;

        for(int i = 0;i < WayNum;i++){
            if(BulletNum == 1){
                GameObject bullet = bulletPool.SpawnFromPool(BulletName,transform.position); //แก้ตรงนี้

                float DirX = bullet.transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
                float DirY = bullet.transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

                Vector3 MoveVector = new Vector3(DirX,DirY,0);
                Vector2 BulletDirection = (MoveVector - bullet.transform.position).normalized; //can *speed to increace speed bullet;

                bullet.GetComponent<Bullet>().MoveSpeed = bulletSpeed;
                bullet.GetComponent<Bullet>().SetMoveDirection(BulletDirection);
            }

            if(BulletNum == 2){
                Vector2 EndBarrelPosition1 = new Vector2(transform.position.x,transform.position.y + 0.5f);
                Vector2 EndBarrelPosition2 = new Vector2(transform.position.x,transform.position.y - 0.5f);

                GameObject bullet1 = bulletPool.SpawnFromPool(BulletName,EndBarrelPosition1);
                GameObject bullet2 = bulletPool.SpawnFromPool(BulletName,EndBarrelPosition2);

                float DirX1 = bullet1.transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
                float DirY1 = bullet1.transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

                float DirX2 = bullet2.transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
                float DirY2 = bullet2.transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

                Vector3 MoveVector1 = new Vector3(DirX1,DirY1,0);
                Vector2 BulletDirection1 = (MoveVector1 - bullet1.transform.position).normalized; //can *speed to increace speed bullet;
                
                Vector3 MoveVector2 = new Vector3(DirX2,DirY2,0);
                Vector2 BulletDirection2 = (MoveVector2 - bullet2.transform.position).normalized;
            
            
                bullet1.GetComponent<Bullet>().MoveSpeed = bulletSpeed;
                bullet2.GetComponent<Bullet>().MoveSpeed = bulletSpeed;

                bullet1.GetComponent<Bullet>().SetMoveDirection(BulletDirection1);
                bullet2.GetComponent<Bullet>().SetMoveDirection(BulletDirection2);
            }

            if(BulletNum == 3){
                Vector2 EndBarrelPosition1 = new Vector2(transform.position.x,transform.position.y + 0.5f);
                Vector2 EndBarrelPosition2 = new Vector2(transform.position.x,transform.position.y - 0.5f);
                Vector2 EndBarrelPosition3 = new Vector2(transform.position.x - 0.5f,transform.position.y);

                GameObject bullet1 = bulletPool.SpawnFromPool(BulletName,EndBarrelPosition1);
                GameObject bullet2 = bulletPool.SpawnFromPool(BulletName,EndBarrelPosition2);
                GameObject bullet3 = bulletPool.SpawnFromPool(BulletName,EndBarrelPosition3);

                float DirX1 = bullet1.transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
                float DirY1 = bullet1.transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

                float DirX2 = bullet2.transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
                float DirY2 = bullet2.transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

                float DirX3 = bullet3.transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;
                float DirY3 = bullet3.transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

                Vector3 MoveVector1 = new Vector3(DirX1,DirY1,0);
                Vector2 BulletDirection1 = (MoveVector1 - bullet1.transform.position).normalized; //can *speed to increace speed bullet;
                
                Vector3 MoveVector2 = new Vector3(DirX2,DirY2,0);
                Vector2 BulletDirection2 = (MoveVector2 - bullet2.transform.position).normalized;

                Vector3 MoveVector3 = new Vector3(DirX3,DirY3,0);
                Vector2 BulletDirection3 = (MoveVector3 - bullet3.transform.position).normalized;
            
            
                bullet1.GetComponent<Bullet>().MoveSpeed = bulletSpeed;
                bullet2.GetComponent<Bullet>().MoveSpeed = bulletSpeed;
                bullet3.GetComponent<Bullet>().MoveSpeed = bulletSpeed;

                bullet1.GetComponent<Bullet>().SetMoveDirection(BulletDirection1);
                bullet2.GetComponent<Bullet>().SetMoveDirection(BulletDirection2);
                bullet3.GetComponent<Bullet>().SetMoveDirection(BulletDirection2);
            }


            angle += angleStep;
        }
    }

    void UpdateShotStep(){
        if(shotStep == ShotStep.StartDelay){
            if(delayTimer > 0f){
                delayTimer -= Time.deltaTime;
                return;
            }else{
                delayTimer = 0f;
                shotStep = ShotStep.StartShot;
            }
        }

        if(shotStep == ShotStep.StartShot){
            Shot();

            delayTimer = delayTime;
            shotStep = ShotStep.WaitDelay;
        }

        if(shotStep == ShotStep.WaitDelay){
            if(delayTimer > 0f){
                shotStep = ShotStep.StartDelay;
            }
        }
    }
}
