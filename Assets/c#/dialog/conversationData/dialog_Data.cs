using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "conversation",menuName ="Create/conversation")]
public class dialog_Data : ScriptableObject
{
    // Start is called before the first frame update
    public List<string> conversation = new List<string>();
}
