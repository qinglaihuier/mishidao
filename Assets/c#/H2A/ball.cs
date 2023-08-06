using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update
    public BallDetail ballDetail;
    public SpriteRenderer spriteRender;
    public new BallName name;
    bool isMatch;  //�ж� �Ƿ������ƥ��
    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
      
    }
    public void setBall(BallDetail newDetail)
    {
        if (newDetail.name != BallName.None)
        {
            ballDetail = newDetail;
            name = newDetail.name;
          
        }

        setSprite(isMatch);
      
    }
    public void setSprite(bool isRight)
    {
        if (isRight)
        {
            spriteRender.sprite = ballDetail.rightSprite;
            isMatch = true;
            GameControl_H2A.Instance.nowRightBallNum++;
            Debug.Log(GameControl_H2A.Instance.nowRightBallNum);
            if (GameControl_H2A.Instance.nowRightBallNum == 6)
            {
                eventHandler.callH2AgameOverEvent();
            }
        }
        else
        {
            if (spriteRender.sprite == ballDetail.rightSprite)
                GameControl_H2A.Instance.nowRightBallNum--;
            spriteRender.sprite = ballDetail.wrongSprite;
          
            isMatch = false;
           
        }
    }
}
