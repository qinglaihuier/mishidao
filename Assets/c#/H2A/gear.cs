using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class gear : interactive
{
    Transform gearTransform;
    private void Start()
    {
        gearTransform = GetComponent<Transform>();
    }
    public override void emptyClick()
    {
        StartCoroutine(tweenRotation());
        eventHandler.callreH2AGame();
    }
    IEnumerator tweenRotation()
    {
        float rotation=0f;
        while (rotation < 180)
        {
            yield return new WaitForSeconds(0.05f);
            rotation += 30;
            gearTransform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
        }
        while (rotation > 0)
        {
            yield return new WaitForSeconds(0.05f);
            rotation -= 30;
            gearTransform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);
        }
    }
    // Start is called before the first frame update

}
