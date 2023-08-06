using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "itemData",menuName ="Create/itemData")]
public class itemData : ScriptableObject
{
    public List<itemDetail> itemData_list = new List<itemDetail>();
    // Start is called before the first frame update

}
[Serializable]
public class itemDetail {
    public itemName theName;
    public Sprite itemSprite;


}

