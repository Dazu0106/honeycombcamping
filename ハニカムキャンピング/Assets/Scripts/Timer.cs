using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp ;


public class Timer : MonoBehaviour
{
    private bool TurnFlag = false ;

    public GameObject PlayerPlease ;
    public WebSocket ws ;
    public string text="" ;
    private string playerNum ;
    //カウントダウン
    private float countdown = 0.0f;

    //時間を表示するText型の変数
    public Text timeText ;


    void Start()
    {
        var url = "ws://172.16.98.82:8080" ;
        ws = new WebSocket(url) ;
        ws.Connect() ;
        ws.OnMessage += (sender , e) => TextWrite(e.Data) ;

        playerNum = PlayerPlease.name.Substring(6,1) ;
    }

    // Update is called once per frame
    void Update()
    {
        //時間をカウントダウンする
        countdown -= Time.deltaTime;

        //時間を表示する
        if(TurnFlag)
        timeText.text = countdown.ToString("f1") + "秒";
        else
        timeText.text = "." ;

        //countdownが0以下になったとき
        if (countdown <= 0 && (TurnFlag))
        {

            //timeText.text = "時間になりました！";
            ws.Send("TurnEnd,timeover") ;
            TurnFlag = false ;
        }
    }

    public void TextWrite(string message)
    {
        text = message ;
       // Debug.Log(text) ;

        if(text == ("Start," + playerNum))
        {
            TurnFlag = true ;
            countdown = 10.0f ;
            text = "" ;
        }
        else
        {
            TurnFlag = false ;
            text = "" ;
        }
    }
}

