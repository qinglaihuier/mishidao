using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inventoryUI : MonoBehaviour
{
    public Button leftButton;
    public Button rightButton;

    public slot slot;

    int currentIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnEnable()
    {
        eventHandler.updateSlot += updateSlot;
        eventHandler.gameReStart += gameReStart;
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnDisable()
    {
        eventHandler.updateSlot -= updateSlot;
        eventHandler.gameReStart -= gameReStart;
    }
    void updateSlot(itemDetail newItemDetail,int newIndex)
    {
        if (newItemDetail == null)
        {
            
            slot.setEmpty();
            currentIndex = -1;
            leftButton.interactable = false;
            rightButton.interactable = false;
        }
        else
        {
            if (newIndex > 0){
                leftButton.interactable = true;
                currentIndex = newIndex;
            }
            if (newIndex == -1)
            {
                leftButton.interactable = false;
                rightButton.interactable = false;
                currentIndex = newIndex+1;
            }
            if (newIndex == 0)
            {
                currentIndex = newIndex;
            }
            slot.setItem(newItemDetail,currentIndex);
           
            
        }
    }
  
    public void switchItem(int amount)  //UI ÇÐ»»ÎïÆ·Âß¼­
    {
        int index = currentIndex + amount;
        if(index == 0)
        {
            leftButton.interactable = false;
            rightButton.interactable = true;
        }
        else if (index >currentIndex)
        {
            leftButton.interactable = true;
            rightButton.interactable = false;
        }
        Debug.Log(index);
        eventHandler.callSwitchItemEvent(index);
    }
    void gameReStart(int weekIndex)
    {
        eventHandler.callUpdateSlotEvent(null, -1);
       
    }
}
