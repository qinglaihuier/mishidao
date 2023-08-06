using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactive : MonoBehaviour
{
     public itemName targetItem;
     
     public bool isDone;   //判断这个交互是否完成
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void interactiveReaction(itemName theItem)
    {
         if (theItem == itemName.None)
        {
            emptyClick();
        }

        else if (targetItem == theItem&& !isDone)
        {
            OnClickAction();
            eventHandler.callItemUsed(theItem);
           
        }
       

    }
    public virtual void OnClickAction()
    {
      
     
     
        
    }
    public virtual void emptyClick()
    {
       
    }
    
}
