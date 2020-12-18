using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using System;

public class ActOrderUI : MonoBehaviour
{
     public WebSocket ws;
     private Vector3 pos0, pos1, pos2, pos3;
     //public GameObject p0, p1, p2, p3;
     //public GameObject[] arr = new GameObject[] {p0, p1, p2, p3};
     
     public GameObject p0 = null;
     public GameObject p1 = null;
     public GameObject p2 = null;
     public GameObject p3 = null;
     private GameObject[] arr;
     public GameObject DisplayPlayer = null;
     private Queue<string> texts = new Queue<string>();

    void Start()
    {
        var url = "ws://172.16.98.82:8080";
        ws = new WebSocket(url);
        ws.Connect();
        ws.OnMessage += (sender , e) => MessageReceive(e.Data) ;

        // 各playerの初期位置を格納
        pos0 = p0.transform.position;
        pos1 = p1.transform.position;
        pos2 = p2.transform.position;
        pos3 = p3.transform.position;

        arr = new GameObject[] {p0,p1,p2,p3};

    }

    // Update is called once per frame
    void Update()
    {   
        if(texts.Count>0){ 
        string text = texts.Dequeue();

            // orderに応じて OrderUIの初期位置を代入していく
            if(text.Contains("order")){
                //Debug.Log(text +" Check") ;
                arr[int.Parse(text.Substring(5,1))].transform.position = pos0;
                arr[int.Parse(text.Substring(6,1))].transform.position = pos1;
                arr[int.Parse(text.Substring(7,1))].transform.position = pos2;
                arr[int.Parse(text.Substring(8,1))].transform.position = pos3;
            }

            // Startの後の数字に応じて DisplayPlayerの色を変えていく
            if(text.Contains("Start,")){
                int TurnPlayer = int.Parse(text.Substring(6,1));
                switch(TurnPlayer){
                    case 0: DisplayPlayer.GetComponent<Renderer>().material.color = new Color(255, 0, 0, 255);
                            Debug.Log("ChangeRed");
                            break; // 赤
                    case 1: DisplayPlayer.GetComponent<Renderer>().material.color = new Color(0, 0, 255, 255);
                            Debug.Log("ChangeBlue");
                            break; // 青
                    case 2: DisplayPlayer.GetComponent<Renderer>().material.color = new Color(0, 255, 0, 255);
                            break; // 緑
                    case 3: DisplayPlayer.GetComponent<Renderer>().material.color = new Color(255, 255, 0, 255);
                            break; // 黄
                    default: Debug.Log("DisplayColor Exception"); 
                            break;
                }
            }

            // ゲームの初期化時のUI設定を書く?
            if(text.Contains("GameSet")){
                DisplayPlayer.GetComponent<Renderer>().material.color = Color.white;
            }
        }

    }

    public void MessageReceive(string message){
        texts.Enqueue(message);
        //text = message;
        //Debug.Log(message);
    }
}
