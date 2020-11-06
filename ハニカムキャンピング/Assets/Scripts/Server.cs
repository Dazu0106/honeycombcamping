using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp ;

public class Server : MonoBehaviour {
    private int count = 0; // click counter
    public WebSocket ws;
    public GameObject player2,player3,player4;
    private string text="";
    void Start () {
        var url = "ws://localhost:8080";
        ws = new WebSocket(url);
        ws.Connect();
        ws.OnMessage += (sender , e) => ReceivTest(e.Data) ;
    }
    void Update () {
       if(text!="") 
       {
           player2.transform.position+=new Vector3(10,0,0);
           text="";
       }

        

        if (Input.GetMouseButtonDown(0))
        {
            
            Debug.Log("clicked!");
            count++;
            //ws.Send("clicked No. " + 
            ws.Send(count.ToString());
        }
    }

    public void ReceivTest(string message)
    {   text=message;
        
        
        
        Debug.Log(text) ;
    }
}