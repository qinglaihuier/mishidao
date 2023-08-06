using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class itemDescribetion : MonoBehaviour
{
    public Text ItemName;
    // Start is called before the first frame update
    public void changeItemName(itemName name)
    {
        ItemName.text = name switch
        {
            itemName.key => "Ô¿³×",
            itemName.ticket => "´¬Æ±",
            _ => ""

        };
    }
}
