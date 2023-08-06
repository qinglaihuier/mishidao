using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData 
{
    // Start is called before the first frame update
    public string currentScene;
    public int weekNum;
    public Dictionary<string, bool> competionOfTheMinigame = new Dictionary<string, bool>();
    public List<itemName> inventory = new List<itemName>();
    public Dictionary<itemName, bool> itemData = new Dictionary<itemName, bool>();
    public Dictionary<string, bool> interactiveData = new Dictionary<string, bool>();
}
