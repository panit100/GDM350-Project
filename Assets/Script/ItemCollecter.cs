using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollecter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Item"){
            other.GetComponent<BaseItem>().DestroyItem();
            other.GetComponent<BaseItem>().Ability();
        }
    }

    
}
