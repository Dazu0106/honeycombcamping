using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp ;

public class Server : MonoBehaviour {
    private int count = 0; // click counter
    public WebSocket ws;
    void Start () {
        var url = "ws://localhost:8080";
        ws = new WebSocket(url);
        ws.Connect();
        ws.OnMessage += (sender , e) => ReceivTest(e.Data) ;
    }
    void Update () {
       

        

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicked!");
            count++;
            ws.Send("clicked No. " + count.ToString());
        }
    }

    public void ReceivTest(string text)
    {
        Debug.Log(text) ;
    }
}