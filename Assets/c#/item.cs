using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
   
    public itemName theName;
    public void beClick()
    {
        
        inventoryManager.Instancee.addItem(theName);
        gameObject.SetActive(false);
    }
    // Start is called before the first frame update
 
}
