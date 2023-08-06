using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum itemName {

    None,key,ticket

}
public enum gameState
{
    Pause,gamePlay
}
[System.Serializable]
public enum BallName
{
    None,B1,B2,B3,B4,B5,B6
}

public interface ISaveData
{
    public void SaveLoadManagerRegistered();
    public GameData saveData();
    public void loadData(GameData BeSavedData);

    
}