using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class dialogControl : MonoBehaviour
{
    public dialog_Data grandma_Empty;
    public dialog_Data grand_Finisgh;
     Stack<string> empty_Convertaion = new Stack<string>();
    Stack<string> finish_Conversation = new Stack<string>();

    public bool isTalking;
    // Start is called before the first frame update
    void Start()
    {
       
        pushDataToStack();
    }
    private void OnEnable()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void pushDataToStack()
    {
        for(int i = grandma_Empty.conversation.Count - 1; i >= 0; i--)
        {
            empty_Convertaion.Push(grandma_Empty.conversation[i]);
        }
        for(int i = grand_Finisgh.conversation.Count - 1; i > -1; i--)
        {
            finish_Conversation.Push(grand_Finisgh.conversation[i]);
        }
    }
   
    public IEnumerator showFinishData()
    {
       
        isTalking = true;
        if (finish_Conversation.Count > 0)
        {
            eventHandler.callChangheCurrentGameStateEvent(gameState.Pause);
            eventHandler.callChangeDialogConversationEvent(finish_Conversation.Pop());
            yield return null;
            isTalking = false;
          
        }
        else
        {
            eventHandler.callChangeDialogConversationEvent(string.Empty);
            eventHandler.callChangheCurrentGameStateEvent(gameState.gamePlay);
            pushDataToStack();
            isTalking = false;
        }
    }
    public IEnumerator showEmptyData()
    {

        isTalking = true;
        if (empty_Convertaion.Count > 0)
        {
            eventHandler.callChangheCurrentGameStateEvent(gameState.Pause);
            eventHandler.callChangeDialogConversationEvent(empty_Convertaion.Pop());
            isTalking = false;
            yield return null;
            
        }
        else
        {
            eventHandler.callChangeDialogConversationEvent(string.Empty);
            eventHandler.callChangheCurrentGameStateEvent(gameState.gamePlay);
            pushDataToStack();
            isTalking = false;
        }
    }
}
