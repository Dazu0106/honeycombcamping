using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using WebSocketSharp;


public class StartButton : MonoBehaviour
{
    public GameObject Button ;
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
        if(text == "readygo")
        {
            SceneManager.LoadScene("Scene_Game") ;
            text = "" ;
        }   
    }

    public void OnclickStartButton()
    {
        //for(int i = 0 ; i < 4 ; i++)
        ws.Send("ready") ;
        //Button.SetActive(false) ;
    }

    public void TitleReceive(string message)
    {
        text = message ;
        // Debug.Log(message);
    }
}
