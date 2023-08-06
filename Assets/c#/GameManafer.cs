using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManafer : MonoBehaviour,ISaveData
{
    static GameManafer instance;
    public static GameManafer Instance
    {
        get
        {
            return instance;
        }
    }


    Dictionary<string, bool> competionOfTheMinigame = new Dictionary<string, bool>();
    public int weekIndex;  //ÖÜÄ¿ÐòºÅ
    
    private void OnEnable()
    {
        eventHandler.gameReStart += gameReStart;
        eventHandler.AfterLoadScene += afterLoadScene;
        eventHandler.H2A_GameOver += updateGameOverDic;
    }
    private void OnDisable()
    {
        eventHandler.gameReStart -= gameReStart;
        eventHandler.AfterLoadScene -= afterLoadScene;
        eventHandler.H2A_GameOver -= updateGameOverDic;
    }
    // Start is called before the first frame update
    private void Awake()
    {
        // eventHandler.callChangheCurrentGameStateEvent(gameState.gamePlay);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        SaveLoadManagerRegistered();
    }
    void afterLoadScene()
    {
       
        foreach(var minigame in FindObjectsOfType<MINIGAME>())
        {
            
            if (competionOfTheMinigame.TryGetValue(minigame.minigameName, out bool isPass))
            {
                
                if (isPass)
                {
                    Debug.Log("callMiniGameOverEvent");
                    minigame.callMiniGameOverEvent();
                }
                else
                {
                    Debug.Log("isNotePasee");
                }
            }
           
            
        }
      
    }
    void updateGameOverDic(string gameName)
    {
        competionOfTheMinigame[gameName] = true;
        
       
    }
    void gameReStart(int weekIndex)
    {
        competionOfTheMinigame.Clear();
    }

    public void SaveLoadManagerRegistered()
    {
        saveLoadManager.Instance.register(this);
    }

    public GameData saveData()
    {
        GameData theData = new GameData();
        theData.weekNum = weekIndex;
        theData.competionOfTheMinigame = competionOfTheMinigame;
        return theData;
    }

    public void loadData(GameData beSavedData)
    {
        this.weekIndex = beSavedData.weekNum;
        this.competionOfTheMinigame = beSavedData.competionOfTheMinigame;
    }

  
}
