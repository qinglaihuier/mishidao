using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using System.IO;
public class saveLoadManager : MonoBehaviour
{
    static saveLoadManager instance;
    List<ISaveData> data_List = new List<ISaveData>();

    Dictionary<string, GameData> allDataDic = new Dictionary<string, GameData>();

    string json;
    public static saveLoadManager Instance { 
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    public void register(ISaveData data)
    {
        data_List.Add(data);
    }
    // Start is called before the first frame update
    void Start()
    {
        json = Application.persistentDataPath + "/Save/";
    }
    private void OnEnable()
    {
        eventHandler.gameReStart += gameReStart;
        eventHandler.continueGame += loadData;
        eventHandler.openMenu += saveData;
    }
    public void OnDisable()
    {
        eventHandler.gameReStart -= gameReStart;
        eventHandler.continueGame -= loadData;
        eventHandler.openMenu -= saveData;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void gameReStart(int week)
    {
        var resultPath = json + "Data.sav";
        if (File.Exists(resultPath))
        {
            File.Delete(resultPath);
        }
    }
    void saveData()
    {
        allDataDic.Clear();
        foreach(var saveable in data_List)
        {
            allDataDic[saveable.GetType().Name] = saveable.saveData();
            
            
        }
        var resultPath = json + "Data.sav";
     
        var resultData = JsonConvert.SerializeObject(allDataDic, Formatting.Indented);

        if (!File.Exists(resultPath))
        {
            Directory.CreateDirectory(json);
        }
        File.WriteAllText(resultPath, resultData);


    }
    void loadData()
    {
        var resultPath = json + "Data.sav";
        if (!File.Exists(resultPath))
        {
           // Debug.LogError("数据存储的文件不存在，加载数据失败");
            return;

        }
        var stringData = File.ReadAllText(resultPath);
        var datadic = JsonConvert.DeserializeObject<Dictionary<string,GameData>>(stringData);
        foreach(var saveable in data_List)
        {
            saveable.loadData(datadic[saveable.GetType().Name]);
        }
    }
}
