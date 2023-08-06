using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{
  
    // Start is called before the first frame update
    public void quitGame()
    {
        Application.Quit();
    }
    public void continueGame()
    {
        eventHandler.callContinueGameEvent();
        Debug.Log("继续游戏");
    }
    public void openMenu()
    {
        var currentScene = SceneManager.GetActiveScene().name;
        eventHandler.callOpemMenuEvent();
        transision.Instance.transisionScene(currentScene, "menu");
  
        //保存游戏状态
    }
    public void loadWeek(int weekNum)
    {
        eventHandler.callGameReStart(weekNum);
        GameManafer.Instance.weekIndex = weekNum;
        transision.Instance.transisionScene("menu", "H1");
    }
}
