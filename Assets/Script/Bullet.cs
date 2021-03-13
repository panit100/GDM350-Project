using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 moveDirection;
    float moveSpeed = 5f;

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir){
        moveDirection = dir;
    }

    private void OnBecameInvisible() {
        Invoke("DestroyBullet",3f);
    }

    private void OnBecameVisible() {
        CancelInvoke();
    }

    void DestroyBullet(){
        gameObject.SetActive(false);
    }

    public float MoveSpeed{
        set{ moveSpeed = value;}
    }
}
