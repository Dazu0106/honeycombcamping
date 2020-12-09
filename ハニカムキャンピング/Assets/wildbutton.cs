using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class wildbutton : MonoBehaviour
{   
    public WebSocket ws;
    public string message;
    public string text = "";
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        var url = "ws://172.16.98.82:8080";
        ws = new WebSocket(url);
        ws.Connect();
        ws.OnMessage += (sender , e) => ReceivTest(e.Data) ;
        i=0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclick()
    {
        if(i==0){
            Debug.Log("tamesi");
            ws.Send("wildC");
            ws.Send("TurnEndRfront") ;
            i=i+1;
        }
    }

    public void ReceivTest(string message)
    {   
        text=message;
        Debug.Log(message) ;
    }
}
