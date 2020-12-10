using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WebSocketSharp;


public class StartButton : MonoBehaviour
{

    public WebSocket ws ;
    public string message  ;
    public string text = "" ;
    // Start is called before the first frame update
    void Start()
    {
        var url = "ws://172.16.98.82:8080" ;
        ws = new WebSocket(url) ;
        ws.Connect() ;
        ws.OnMessage += (sender , e) => TitleReceive(e.Data) ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnclickStartButton()
    {
        SceneManager.LoadScene("Scene_Game") ;
        ws.Send("ready") ;
    }

    public void TitleReceive(string message)
    {
        text = message ;
    }
}
