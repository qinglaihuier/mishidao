using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MINIGAME : MonoBehaviour
{
    public UnityEvent miniGameOver;
    public string minigameName;
    bool isPass;     //�Ƿ����
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void callMiniGameOverEvent()
    {
        
        isPass = true;
        gameObject.SetActive(false);
        miniGameOver?.Invoke();
       
    }
}
