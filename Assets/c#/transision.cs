using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class transision :MonoBehaviour,ISaveData
{
    static transision instance;

    public CanvasGroup panel;
    public string startScene ;
    bool isFade;
    bool canTransision;
    public float fadeTime;
    
    public static transision Instance
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
            Destroy(this);
        }
        StartCoroutine(transisionSceneC(string.Empty, startScene));
    }
    private void OnEnable()
    {
        eventHandler.changeCurrentGameStateEvent += dicideIfCanTransision;
        eventHandler.callChangheCurrentGameStateEvent(gameState.gamePlay);
    }
    private void OnDisable()
    {
        eventHandler.changeCurrentGameStateEvent -= dicideIfCanTransision;
    }
    void dicideIfCanTransision(gameState newState)
    {
        canTransision = newState == gameState.gamePlay;
    }
    public void transisionScene(string originScene,string targetScene)
    {
        if(!isFade&&canTransision)
        StartCoroutine(transisionSceneC(originScene, targetScene));
     
    }
    IEnumerator transisionSceneC(string originScene,string targetScene)
    {
        
        yield return fade(1);
        if (originScene != "")
        {
     
            eventHandler.callBeforeUploadScene();
            yield return SceneManager.UnloadSceneAsync(originScene);
        }
       
        yield return SceneManager.LoadSceneAsync(targetScene,LoadSceneMode.Additive);
   
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);
        eventHandler.callAfterLoadSceneEvent();
         StartCoroutine(fade(0));
       
    }
    IEnumerator fade(float targetFade)
    {
       
        isFade = true;
        float speed = Mathf.Abs(targetFade - panel.alpha) / fadeTime;
        while (!Mathf.Approximately(targetFade, panel.alpha))
        {
            panel.alpha = Mathf.MoveTowards(panel.alpha, targetFade, speed * Time.deltaTime);
            yield return null;
        }
        isFade = false;
    }

    public void SaveLoadManagerRegistered()
    {
        saveLoadManager.Instance.register(this);
    }

    public GameData saveData()
    {
        GameData data = new GameData();
        data.currentScene = SceneManager.GetActiveScene().name;
        Debug.Log(data.currentScene);
        return data;
    }

    public void loadData(GameData BeSavedData)
    {
       
        StartCoroutine(transisionSceneC("menu", BeSavedData.currentScene));
        Debug.Log("×ª»»×ª»»°¡");
    }
    // Start is called before the first frame update

}
