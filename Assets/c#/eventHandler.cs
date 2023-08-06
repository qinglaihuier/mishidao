using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public static class eventHandler 
{
    static public event Action<itemDetail, int> updateSlot;
    // Start is called before the first frame update
    static public void callUpdateSlotEvent(itemDetail itemDetail,int newIndex)
    {
        updateSlot(itemDetail, newIndex);
    }


    static public event Action AfterLoadScene;
    static public void callAfterLoadSceneEvent()
    {
        AfterLoadScene();
    }


    static public event Action beforeUploadScene;
    static public void callBeforeUploadScene()
    {
        beforeUploadScene.Invoke();
    }

    static public event Action<itemName,bool> holdItem;
    static public void callHoldItenEvent(itemName name,bool isSelected)
    {
        holdItem.Invoke(name,isSelected);

    }
    static public event Action<itemName> itemBeUsed;
    static public void callItemUsed(itemName name)
    {
        itemBeUsed(name);
    }
    static public event Action<int> switchItemEvent;
    static public void callSwitchItemEvent(int index)
    {
        switchItemEvent.Invoke(index);
    }
    static public event Action<string> changeDialogConversationEvent;
    static public void callChangeDialogConversationEvent(string newConversation)
    {
       
        changeDialogConversationEvent.Invoke(newConversation);
    }
    static public event Action<gameState> changeCurrentGameStateEvent;
    static public void callChangheCurrentGameStateEvent(gameState newState)
    {
        changeCurrentGameStateEvent.Invoke(newState);
    }
    static public event Action H2AGameOver;
    static public void callH2AgameOverEvent()
    {
        H2AGameOver?.Invoke();
    }
    static public event Action reH2AGame;
    static public void callreH2AGame()
    {
        reH2AGame?.Invoke();
    }
    public static event Action<string> H2A_GameOver;
    public static void callH2A_GameOver(string gameName)
    {
        H2A_GameOver?.Invoke(gameName);
    }
    public static event Action<int> gameReStart;
    public static void callGameReStart(int weekIndex)
    {
        gameReStart?.Invoke(weekIndex);
    }
    public static event Action openMenu;
    public static void callOpemMenuEvent()
    {
        openMenu?.Invoke();
    }
    public static event Action continueGame;
    public static void callContinueGameEvent()
    {
        continueGame?.Invoke();
    }
}
