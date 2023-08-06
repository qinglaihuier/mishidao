using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class mouseDection : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 mousePosition;
    GameObject beDetectedItem;

    itemName noewHoldItem = itemName.None;

    bool isHold;

    public Image hand;

    void Start()
    {
        
    }
    private void OnEnable()
    {
        eventHandler.gameReStart += gameReStart;
        eventHandler.holdItem += holdItem;
        eventHandler.itemBeUsed += itemBeUsed;
    }
    private void OnDisable()
    {
        eventHandler.gameReStart -= gameReStart;
        eventHandler.holdItem -= holdItem;
        eventHandler.itemBeUsed -= itemBeUsed;
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.mousePosition);
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        checkCollider2D();
        handTracking();
    }
    void checkCollider2D()
    {
      

        if (Physics2D.OverlapPoint(mousePosition) && Input.GetMouseButtonDown(0))
        {
            Instantiate(new GameObject());
            beDetectedItem = Physics2D.OverlapPoint(mousePosition).gameObject;
          
            chooseReaction(beDetectedItem);
        }
    }
    void chooseReaction(GameObject item)
    {
       
        switch (item.tag) {
            case "transision":
               
                item.GetComponent<transitionSceneArrow>().transisionScene();
                break;
            case "item":
              
                var theItem = item.GetComponent<item>();
                theItem?.beClick();
                break;
            case "interactive":
               
                var inteItem = item.GetComponent<interactive>();
                if (isHold)
                    inteItem?.interactiveReaction(noewHoldItem);
                else
                    inteItem?.emptyClick();
                break;
        
        
        }
    
    }
    void itemBeUsed(itemName name)
    {
        hand.gameObject.SetActive(false);
        isHold = false;
        noewHoldItem = itemName.None;
    }

    void handTracking()
    {
        if (isHold)
        {
            hand.rectTransform.anchoredPosition = Input.mousePosition;

           
           
        }
    }
    void holdItem(itemName name,bool isSelected)
    {
        
        isHold = isSelected;
        hand.gameObject.SetActive(isHold);
        Debug.Log(isHold);
        if (isSelected)
        {
            noewHoldItem = name;
        }
    }
   void gameReStart(int weekIndex)
    {
        hand.gameObject.SetActive(false);
        isHold = false;
        noewHoldItem = itemName.None;
    }
}
