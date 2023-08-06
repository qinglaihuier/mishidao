using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transitionSceneArrow : MonoBehaviour
{
    // Start is called before the first frame update
    public string originScene;
    public string targetScene;
    
    public void transisionScene()
    {
        transision.Instance.transisionScene(originScene, targetScene);
    }
   
}
