using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowItemManager : MonoBehaviour
{
    public RectTransform parent;
    OrderIntArray array = new OrderIntArray();
    public List<Text> lastItemText = new List<Text>();
    public void AddItem(string item){
        array.Add(item);
        UpdateText();
    }

    void UpdateText(){
        for(int n = 0; n < lastItemText.Count;n++){
            lastItemText[n].text = array.Items[n];
        }
    }
}
