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
     public GameObject DisplayPlayer;

     private GameObject[] arr;
     private Queue<string> texts = new Queue<string>();

    void Start()
    {
        var url = "ws://172.16.98.82:8080";
        ws = new WebSocket(url);
        ws.Connect();
        ws.OnMessage += (sender , e) => MessageReceive(e.Data) ;

        // 各playerの初期位置を格納
        pos0 = p0.transform.position;//GameObject.Find("p0").transform.position;
        pos1 = p1.transform.position;//GameObject.Find("p1").transform.position;
        pos2 = p2.transform.position;//GameObject.Find("p2").transform.position;
        pos3 = p3.transform.position;//GameObject.Find("p3").transform.position;

        
        arr = new GameObject[] {p0,p1,p2,p3} ;
        
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
                switch(text.Substring(6,1)){
                    case 0: DisplayPlayer.GetComponent<Renderer>().material.Color = new Color(229, 46, 46, 255);
                            break;
                    case 1: DisplayPlayer.GetComponent<Renderer>().material.Color = new Color(50, 137, 248, 255);
                            break;
                    case 2: DisplayPlayer.GetComponent<Renderer>().material.Color = new Color(0, 255, 4, 255);
                            break;
                    case 3: DisplayPlayer.GetComponent<Renderer>().material.Color = new Color(255, 241, 1, 255);
                            break;
                    default: Debug.Log("DisplayColor Exception");
                }
            }

            // ゲームの初期化自のUI設定を書く?
        }

    }

    public void MessageReceive(string message){
        texts.Enqueue(message);
        //text = message;
        //Debug.Log(message);
    }
}
