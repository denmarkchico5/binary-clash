using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PowerCardAreaUpdate : MonoBehaviour
{ 
    void Update() 
    {
         AreaUpdate();
    }
    public void AreaUpdate() 
    {
        foreach (Transform child in transform) 
        {
            child.gameObject.tag = "Discarded";
        }
    }
    public void offDrag() 
    {
        foreach (Transform card in transform) 
        {
            card.GetComponent<DragDropPowerCards>().enabled = false;
        }
    }
}
