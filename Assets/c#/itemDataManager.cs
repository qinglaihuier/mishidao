using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDataManager : MonoBehaviour,ISaveData
{
    Dictionary<itemName, bool> itemData = new Dictionary<itemName, bool>();
    Dictionary<string, bool> interactiveData = new Dictionary<string, bool>();
    static itemDataManager instance;
    public static itemDataManager Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        SaveLoadManagerRegistered();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
       
    }
    private void OnEnable()
    {
        eventHandler.gameReStart += gameReStart;
        eventHandler.beforeUploadScene += beforeUploadScene;
        eventHandler.AfterLoadScene += AfterLoadScene;
        eventHandler.updateSlot += OnUpdateUiEvent;
       
    }
    private void OnDisable()
    {
        eventHandler.gameReStart -= gameReStart;
        eventHandler.beforeUploadScene -= beforeUploadScene;
        eventHandler.AfterLoadScene -= AfterLoadScene;
        eventHandler.updateSlot -= OnUpdateUiEvent;
      
    }
    // Start is called before the first frame update
    public  void AfterLoadScene()  //加载场景之后去  更新 调控物品的信息
    {
        foreach(var item in FindObjectsOfType<item>())
        {
            if (!itemData.ContainsKey(item.theName))
            {
                itemData.Add(item.theName, true);
            }
            else
            {
                if (item.theName == itemName.ticket)
                {
                   // Debug.Log(itemData[item.theName]);
                }

                item.gameObject.SetActive(itemData[item.theName]);
                if (item.theName == itemName.ticket)
                {
                  //  Debug.Log(item.gameObject.activeInHierarchy);
                }
            }
        }
        foreach(var interactiveItem in FindObjectsOfType<interactive>())
        {
            if (!interactiveData.ContainsKey(interactiveItem.name))
            {
                interactiveData.Add(interactiveItem.name, false);
            }
            else
            {
                interactiveItem.isDone = interactiveData[interactiveItem.name];
            }
        }
       

    }
    public void beforeUploadScene()  //卸载场景 之前更新itemData 信息
    {
        foreach (var item in FindObjectsOfType<item>())
        {
            if (!itemData.ContainsKey(item.theName))
            {
                itemData.Add(item.theName, true);
            
            }
          
        }
        foreach (var item in FindObjectsOfType<interactive>())
        {
            if (!interactiveData.ContainsKey(item.name))
            {
                interactiveData.Add(item.name,item.isDone);

            }
            else
            {
                interactiveData[item.name] = item.isDone;
            }

        }

    }
    void OnUpdateUiEvent(itemDetail itemDetail, int newIndex)
    {
        if (itemDetail != null)
        {
            itemData[itemDetail.theName] = false;
        }
    }
   void gameReStart(int weekIndex)
    {
        itemData.Clear();
        interactiveData.Clear();
    }

    public void SaveLoadManagerRegistered()
    {
        saveLoadManager.Instance.register(this);
    }

    public GameData saveData()
    {
        GameData data = new GameData();
        data.itemData = itemData;
        data.interactiveData = interactiveData;
        return data;
    }

    public void loadData(GameData BeSavedData)
    {
        this.interactiveData = BeSavedData.interactiveData;
        this.itemData = BeSavedData.itemData;
    }
}
