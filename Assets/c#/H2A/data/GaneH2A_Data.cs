using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameH2A_Data",menuName ="Create/GameH2A_Data")]
public class GaneH2A_Data : ScriptableObject
{
    public string gameName;
    public Dictionary<string, bool> completionOfTheMinigame = new Dictionary<string, bool>();

    // Start is called before the first frame update
    public   List<BallDetail> balls_List = new List<BallDetail>();

    public List<LinePosition> linePosition_List = new List<LinePosition>();
    
    public List<BallName> ballPosition_List = new List<BallName>();   //对应编号洞下 存放对应小球
    public BallDetail getBallDetail(BallName name)
    {
        return balls_List.Find(b => b.name==name);
    }
  
    
}

[System.Serializable]
public class BallDetail
{
    public BallName name;
    public Sprite rightSprite;
    public Sprite wrongSprite;
}
[System.Serializable]
public class LinePosition
{
    public int beginPosition;
    public int endPosition;
}

