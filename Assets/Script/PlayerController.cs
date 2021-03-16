using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Setting")]
    [SerializeField]

    public float moveSpeed = 0f;

    void FixedUpdate()
    {
        moveSpeed = Player.Speed;

        Controller();
    }

    void Controller(){
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector2 playerPosition = new Vector2(horizontal, vertical);
        transform.Translate(playerPosition);
        
    }
}
