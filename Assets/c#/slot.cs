using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class slot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    // Start is called before the first frame update
    itemDetail theItemDetail;
   
    public Image slotImage;

    public Image itemDescription;

    bool isSelected;
    
    public void setItem(itemDetail newItemDetail,int newItemIndex)
   {
        gameObject.SetActive(true);
        theItemDetail = newItemDetail;
       
        slotImage.sprite = newItemDetail.itemSprite;
        slotImage.SetNativeSize();
        isSelected = false;
   }
    public void setEmpty()
    {
      
        gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = !isSelected;
        eventHandler.callHoldItenEvent(theItemDetail.theName, isSelected);
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        itemDescription.gameObject.SetActive(true);
        itemDescription.GetComponent<itemDescribetion>().changeItemName(theItemDetail.theName);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        itemDescription.gameObject.SetActive(false);
    }
    
   

  
}
