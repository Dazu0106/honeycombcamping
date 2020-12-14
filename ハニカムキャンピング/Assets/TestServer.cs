using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp ;

public class TestServer : MonoBehaviour {
    private int count = 0; // click counter
    public WebSocket ws;
    void Start () {
        var url = "ws://172.16.98.82:8080";
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

        if(Input.GetKeyDown(KeyCode.P))
        {
            ws.Send("GameSet") ;
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            ws.Send("order") ;
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            ws.Send("wildC") ;
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            ws.Send("TurnEndRfront") ;
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            ws.Send("TurnEndRight") ;
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            ws.Send("TurnEndRback") ;
        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            ws.Send("TurnEndLback") ;
        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            ws.Send("TurnEndLeft") ;
        }

        if(Input.GetKeyDown(KeyCode.U))
        {
            ws.Send("TurnEndLfront") ;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            ws.Send("ready") ;
        }
    }

    public void ReceivTest(string text)
    {
        Debug.Log(text) ;
    }
}