using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 moveDirection;
    float moveSpeed = 5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    void SetMoveDirection(Vector2 dir){
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
}
