using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoder : interactive
{
   public ball theHoderBall;
   public bool isEmpty;
    public BallName targetName; //�������Ŀ��С�� ����
    [SerializeField]
    public HashSet<hoder> connectHole = new HashSet<hoder>(); //����������ӵĶ�
    public override void emptyClick()
    {
      if(!isEmpty)
       foreach(var n in connectHole)
        {
            if (n.isEmpty)
            {
                theHoderBall.transform.position = n.transform.position;
                theHoderBall.transform.SetParent(n.transform);
                theHoderBall.setSprite(n.targetName == theHoderBall.name);
                isEmpty = true;
                n.isEmpty = false;
               
                n.theHoderBall = theHoderBall;
                theHoderBall = null;
                    break;
            }
        }
    }
    void f(in int s)
    {
      
    }

}
    // Start is called before the first frame update
 


