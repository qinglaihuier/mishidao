using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameControl_H2A : MonoBehaviour
{
    static GameControl_H2A instance;
    public UnityEvent onFinish;
    public static GameControl_H2A Instance
    {
        get
        {
            return instance;
        }
    }
    

    // Start is called before the first frame update
    public GaneH2A_Data game_H2A_Data;
    public GaneH2A_Data[] allWeeksData;

    public Transform[] holderPositions;
    public GameObject linePrefab;
    public GameObject ballPrefab;
    public GameObject lineParent;
     public int nowRightBallNum; //目前到达对应位置的球
    private void Awake()
    {
        game_H2A_Data = allWeeksData[GameManafer.Instance.weekIndex];
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            Debug.Log("你又创建了一个gamecontrol——H2A，请注意");
        }
    }
    void Start()
    {
      
        Initiallize();
    }
    private void OnEnable()
    {
        eventHandler.H2AGameOver += gameOver;
        eventHandler.reH2AGame += reGame;
    }
    private void OnDisable()
    {
        eventHandler.H2AGameOver -= gameOver;
        eventHandler.reH2AGame -= reGame;
    }
    // Update is called once per frame
    void Initiallize()
    {
        foreach(var Connection in game_H2A_Data.linePosition_List) //生成线
        {
            setLineConnectData(Connection);

           GameObject newLine = Instantiate(linePrefab);
            newLine.transform.SetParent(lineParent.transform);
            newLine.GetComponent<LineRenderer>().SetPosition(0, holderPositions[Connection.beginPosition].position);
            newLine.GetComponent<LineRenderer>().SetPosition(1, holderPositions[Connection.endPosition].position);
            
        }
       for(int i=0;i < game_H2A_Data.ballPosition_List.Count; i++)//生成球
        {
            if (game_H2A_Data.ballPosition_List[i] == BallName.None)
            {
                holderPositions[i].GetComponent<hoder>().isEmpty = true;
                continue;
            }
             holderPositions[i].GetComponent<hoder>().isEmpty = false;
            GameObject ball = Instantiate(ballPrefab, holderPositions[i]);
            ball.transform.position = holderPositions[i].position;
                   
            ball.GetComponent<ball>().setBall(game_H2A_Data.getBallDetail(game_H2A_Data.ballPosition_List[i]));
            holderPositions[i].GetComponent<hoder>().theHoderBall = ball.GetComponent<ball>();
                
        }
    }
    void setLineConnectData(LinePosition line)//设置洞之间的链接数据
    {
        holderPositions[line.beginPosition].GetComponent<hoder>().connectHole.Add(holderPositions[line.endPosition].GetComponent<hoder>());  
        holderPositions[line.endPosition].GetComponent<hoder>().connectHole.Add(holderPositions[line.beginPosition].GetComponent<hoder>());
    }
    void gameOver()
    {
        eventHandler.callH2A_GameOver(game_H2A_Data.gameName);
        onFinish?.Invoke();
    }
    void reGame()
    {
        foreach(var n in holderPositions)
        {
            if (n.childCount > 0)
            {
                Destroy(n.GetChild(0).gameObject);
            }
        }
       for(int i = 0; i < lineParent.transform.childCount; i++)
        {
            Destroy(lineParent.transform.GetChild(i).gameObject);
        }
        Initiallize();
    }
    public void closeCollider2D()
    {
        foreach(var n in holderPositions)
        {
            n.GetComponent<Collider2D>().enabled = false;
        }
    }
}
