using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour
{
    ShowItemManager showItemManager;
    float timeBeforeDestroy = 10f;
    float timer = 0;

    [Header("Stat")]
    public float speed = 0;
    public float damage = 0;
    public float fireRate = 0;
    public int bulletNum = 0;
    public float bulletSpeed = 0;
    public float scale = 0;
    public bool shield = false;

    private void Start() {
        showItemManager = FindObjectOfType<ShowItemManager>().GetComponent<ShowItemManager>();
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = RandomVector();    
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if(timer >= timeBeforeDestroy){
            DestroyItem();
        }
    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Ability();
            showItemManager.AddItem(this.name);
            DestroyItem();
        }
    }

    public virtual void Ability(){
        //do something
    }

    public void DestroyItem(){
        Destroy(gameObject);
    }

    Vector2 RandomVector(){
        float x = Random.Range(-2f,0f);
        float y = Random.Range(-1f,1f);

        return new Vector2(x,y);
    }
}
