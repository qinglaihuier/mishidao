using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryManager : MonoBehaviour,ISaveData
{
    static inventoryManager instance;
    public static inventoryManager Instancee
    {
        get
        {
            return instance;
        }
    }

   public List<itemName> inventory = new List<itemName>();
    public itemData itemDatas;
    
    private void Awake()
    {
        SaveLoadManagerRegistered();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void OnEnable()
    {
        eventHandler.gameReStart += gameReStart;
        eventHandler.itemBeUsed += deleteItem;
        eventHandler.switchItemEvent += switchItemEvent;
        eventHandler.AfterLoadScene += AfterLoadScene;
    }
    private void OnDisable()
    {
        eventHandler.gameReStart -= gameReStart;
        eventHandler.itemBeUsed -= deleteItem;
        eventHandler.switchItemEvent -= switchItemEvent;
        eventHandler.AfterLoadScene += AfterLoadScene;
    }
    public void addItem(itemName name)
    {
        if (!inventory.Contains(name))
        {
            inventory.Add(name);
        }
        eventHandler.callUpdateSlotEvent(findItemDetail(name), inventory.Count - 1);
       
    }
    
    
    
    public itemDetail findItemDetail(itemName name)
    {
        itemDetail x = new itemDetail();
        for(int i = 0; i < itemDatas.itemData_list.Count; i++)
        {
            if (name == itemDatas.itemData_list[i].theName)
            {
              x=itemDatas.itemData_list[i];
                break;
            }
        }
        
        return x;
    }
    void deleteItem(itemName name)
    {
        int index = getIndex(name);
        inventory.RemoveAt(index);
        if (inventory.Count == 0)
        {
            eventHandler.callUpdateSlotEvent(null, -1);
        }

        else
        {

        }
    }
    int getIndex(itemName name)
    {
        for(int i = 0; i < inventory.Count; i++)
        {
            if (name == inventory[i])
            {
                return i;
            }
        }
        return -1;
    }
    // Start is called before the first frame update
    void switchItemEvent(int index)
    {
        itemDetail newDetail = findItemDetail(inventory[index]);
        eventHandler.callUpdateSlotEvent(newDetail,index);
    }
    void AfterLoadScene()
    {
        if (inventory.Count==0)
        {
            eventHandler.callUpdateSlotEvent(null, -1);
        }
        else
        {
            for(int i = 0; i < inventory.Count; i++)
            {
                eventHandler.callUpdateSlotEvent(findItemDetail(inventory[i]), i);
            }
        }
    }
    void gameReStart(int weekIndex)
    {
        inventory.Clear();
    }

    public void SaveLoadManagerRegistered()
    {
        saveLoadManager.Instance.register(this);
    }

    public GameData saveData()
    {
        GameData theData = new GameData();
        theData.inventory = inventory;
        return theData;
    }

    public void loadData(GameData BeSavedData)
    {
        this.inventory = BeSavedData.inventory;
    }
}
