using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Setting")]
    [SerializeField]
    private float moveSpeed = 0f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Controller();
    }

    void Controller(){
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector2 playerPosition = new Vector2(horizontal, vertical);
        transform.Translate(playerPosition);
        
    }
}
