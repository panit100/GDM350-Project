using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Setting")]
    [SerializeField]
    public float moveSpeed = 0f;

    Player player;

    private void Start() {
        player = FindObjectOfType<Player>().GetComponent<Player>();
    }
    void FixedUpdate()
    {
        moveSpeed = player.Speed;

        Controller();

        
    }

    void Controller(){
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector2 playerPosition = new Vector2(horizontal, vertical);
        transform.Translate(playerPosition);
        
    }
}
