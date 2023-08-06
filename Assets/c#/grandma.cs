using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(dialogControl))]
public class grandma : interactive
{
    public dialogControl dialogControl;
   
    public override void emptyClick()

    {
        if(!dialogControl.isTalking&&!isDone)
             dialogControl.StartCoroutine("showEmptyData");
        else if (isDone)
        {
            dialogControl.StartCoroutine("showFinishData");
          
        }
    }
    public override void OnClickAction()
    {
      
        if (!dialogControl.isTalking && !isDone)
        {
            dialogControl.StartCoroutine("showFinishData");
            isDone = true;
        }
          
    }
    // Start is called before the first frame update

}
