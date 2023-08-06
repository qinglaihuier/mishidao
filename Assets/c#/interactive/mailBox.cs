using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mailBox : interactive
{
    SpriteRenderer spriteRender;
    public Sprite openSprite;
    public GameObject mail;
    Collider2D coll;
    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        
        coll = GetComponent<Collider2D>();
       
    }
    private void OnEnable()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        eventHandler.AfterLoadScene += afterLoadScene;
        eventHandler.beforeUploadScene += beforeUploadScene;
    }
    private void OnDisable()
    {
        eventHandler.AfterLoadScene -= afterLoadScene;
        eventHandler.beforeUploadScene -= beforeUploadScene;
    }
    public override void OnClickAction()
    {
        spriteRender.sprite = openSprite;
        coll.enabled = false;
        isDone = true;
        mail.SetActive(true);
       
    }
    private void Update()
    {
     
    }
    public override void emptyClick()
    {
        Debug.Log("–≈œ‰ ø’µ„");
    }
    void afterLoadScene()
    {
        if (!isDone)
        {
            mail.SetActive(false);
           
        }
        else
        {
           
            spriteRender.sprite = openSprite;
            coll.enabled = false;
            Debug.Log(transform.GetChild(0).gameObject.activeInHierarchy);
        }
    }
    void beforeUploadScene()
    {

    }
    // Start is called before the first frame update

}
