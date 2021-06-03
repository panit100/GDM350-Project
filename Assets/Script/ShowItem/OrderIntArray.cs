using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class OrderIntArray : IntDynamicArray
{
    public OrderIntArray() : base(){

    }

    //แก้
    public override void Add(string item)
    {
        if(count == items.Length){
            Expand();
        }
        int addLocation = 0;
        ShiftUp(addLocation);
        items[addLocation] = item;
        count++;
    }

    void ShiftUp(int index){
        for(int i = count;i > index;i--){
            items[i] = items[i-1];
        }
    }

    void ShiftDown(int index){
        for(int i = index;i < count;i++){
            items[i-1] = items[i]; 
        }
    }
}
