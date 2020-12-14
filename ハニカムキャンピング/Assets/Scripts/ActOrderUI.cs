using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class ActOrderUI : MonoBehaviour
{
     public WebSocket ws;
     private string text = "";

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        var url = "172.16.98.82:8080";
        ws = new WebSocket(url);
        ws.Connect();
        ws.OnMessage += (sender , e) => MessageReceive(e.Data) ;
    }

    public void MessageReceive(string message){
        text = message;
        Debug.Log(message);
    }
}
