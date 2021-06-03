using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;

abstract class IntDynamicArray
{
    const int ExpandPlusFector = 2;
    protected string[] items;
    protected int count;

    protected IntDynamicArray(){
        items = new string[6];
        count = 0;
    }

    public abstract void Add(string item);

    protected void Expand(){
        string[] newItems = new string[items.Length * ExpandPlusFector];
        for(int i = 0; i < items.Length; i++){
            newItems[i] = items[i];
        }
        items = newItems;
    }

    public int Count{
        get {
            return count;
        }
    }

    public void Clear(){
        count = 0;
    }

    public string[] Items{
        get{
            return items;
        }
    }

    
}
