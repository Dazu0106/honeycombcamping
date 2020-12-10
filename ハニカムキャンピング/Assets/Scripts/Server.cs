
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.Tilemaps;

public class Server : MonoBehaviour {
    public WebSocket ws;
    public GameObject[] player = new GameObject[3];
    public Tilemap Tilemap;
    public Color[] playercolor = new Color[3];
    
    private string text="";
    private string[] directionMsg = {"Rfront","Right","Rback","Lback","Left","Lfront"};

    　
    
   
    void Awake ()
        {
            for (int i = 0; i < 3; i++)
            {
                UpdateTileColor(player[i],playercolor[i]);
            }
          
        }


    void Start () {
        var url = /*"ws://172.16.98.82:8080";*/"ws://localhost:8080";
        ws = new WebSocket(url);
        ws.Connect();
        ws.OnMessage += (sender , e) => ReceivTest(e.Data) ;

    }
    void Update () {
        //Debug.Log(directionMsg[0]+",0");
       if(text==directionMsg[0]+",0") 
       {
           
            player[0].transform.position+=new Vector3(0.8f,0,0);
            player[1].transform.position+=new Vector3(-0.4f,-0.6f);
            player[2].transform.position+=new Vector3(-0.4f,0.6f);
            
            UpdateTileColor(player[0],playercolor[0]);
            UpdateTileColor(player[1],playercolor[1]);
            UpdateTileColor(player[2],playercolor[2]);
            text="";
            
           
       } 
       

        

     
    }

    public void ReceivTest(string message)
    {   text=message;
            
    }

    public void UpdateTileColor(GameObject player,Color playercolor)
    {   //var tilemap = GetComponent<Tilemap>();//Tilemapを取得
        Vector3Int currentPlayerTile = Tilemap.WorldToCell(player.transform.position);//現在いるTileの座標を取得
        Tilemap.SetTileFlags(currentPlayerTile, TileFlags.None);//Tileのフラグをtrueに
        Tilemap.SetColor( currentPlayerTile, playercolor );//Tileのcolorをplayercolorに変更
        //Debug.Log(playercolor);
    }

    
}
