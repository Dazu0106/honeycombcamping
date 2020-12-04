using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp ;


public class Timer : MonoBehaviour
{
    public bool TurnFlag = true ;
    public WebSocket ws ;
    public string text="" ;
    public int playerNum =  0;
    //カウントダウン
    public float countdown = 10.0f;

    //時間を表示するText型の変数
    public Text timeText ;


    void Start()
    {
        var url = "ws://172.16.98.82:8080" ;
        ws = new WebSocket(url) ;
        ws.Connect() ;
        ws.OnMessage += (sender , e) => TextWrite(e.Data) ;
    }

    // Update is called once per frame
    void Update()
    {
        //時間をカウントダウンする
        countdown -= Time.deltaTime;

        //時間を表示する
        timeText.text = countdown.ToString("f1") + "秒";

        //countdownが0以下になったとき
        if (countdown <= 0 && (TurnFlag))
        {

            timeText.text = "時間になりました！";
            ws.Send("turnEnd,timeover") ;
            TurnFlag = false ;
        }

        if(text == (playerNum + ",Start"))
        {
            countdown = 10.0f ;
            text = "" ;
        }
    }

    public void TextWrite(string message)
    {
        text = message ;
    }
}

