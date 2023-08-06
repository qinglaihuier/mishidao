using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dialogUI : MonoBehaviour
{
    public GameObject dialog;
    public Text conversation;
    // Start is called before the first frame update
    private void Awake()
    {
        eventHandler.changeDialogConversationEvent += changeConversation;
     
    }

    private void OnDestroy()
    {
        eventHandler.changeDialogConversationEvent -= changeConversation;
    }
    void changeConversation(string newConversation)
    {
        
        if (newConversation == "")
        {
            dialog.SetActive(false);
        }
        else
        {
            dialog.SetActive(true);
            conversation.text = newConversation;
        }
    }
}
