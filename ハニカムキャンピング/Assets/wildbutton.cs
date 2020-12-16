using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class wildbutton : MonoBehaviour
{   
    public GameObject Bullet;
    public GameObject wildButton;
    public WebSocket ws;
    private bool TurnFlag=false;
    public string message;
    public string text = "";
    private string playerNum;
    // Start is called before the first frame update
    void Start()
    {
        
        var url = "ws://172.16.98.82:8080";
        ws = new WebSocket(url);
        ws.Connect();
        ws.OnMessage += (sender , e) => ReceivTest(e.Data) ;
        //playerNum=Bullet.GetComponent<ActControllerManager>().player.name;
        playerNum=Bullet.name.Substring(6,1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclick()
    {
            if(TurnFlag){
            // Debug.Log("tamesi");
            ws.Send("wildC");
            // ws.Send("TurnEndRfront") ;
            wildButton.SetActive(false);
            }
    }

    public void ReceivTest(string message)
    {   
        text=message;
        //Debug.Log(message) ;
        if(text == ("Start," + playerNum))
        {
            TurnFlag = true ;
            text = "" ;
        }else {
            TurnFlag=false;
        }
    }
}
