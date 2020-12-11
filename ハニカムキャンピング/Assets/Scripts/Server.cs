
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
        var url = "ws://172.16.98.82:8080";//"ws://localhost:8080";
        ws = new WebSocket(url);
        ws.Connect();
        ws.OnMessage += (sender , e) => ReceivTest(e.Data) ;

    }
    void Update () {
        //Debug.Log(directionMsg[0]+",0");
        if(text==directionMsg[0]+",1") 
        {    
            player[0].transform.position+=new Vector3(0.4f,0.6f,0);//プレイヤー0が右上に移動
            UpdateTileColor(player[0],playercolor[0]);
            text="";
        }

        if(text==directionMsg[1]+",1") 
        {    
            player[0].transform.position+=new Vector3(0.8f,0,0);//プレイヤー0が右に移動
            UpdateTileColor(player[0],playercolor[0]);
            text="";
        }   
        
        if(text==directionMsg[2]+",1") 
        {    
            player[0].transform.position+=new Vector3(0.4f,-0.6f,0);//プレイヤー0が右下に移動
            UpdateTileColor(player[0],playercolor[0]);
            text="";
        }
        
        if(text==directionMsg[3]+",1") 
        {    
            player[0].transform.position+=new Vector3(-0.4f,-0.6f,0);//プレイヤー0が左下に移動
            UpdateTileColor(player[0],playercolor[0]);
            text="";
        }

        if(text==directionMsg[4]+",1") 
        {    
            player[0].transform.position+=new Vector3(-0.8f,0,0);//プレイヤー0が左に移動
            UpdateTileColor(player[0],playercolor[0]);
            text="";
        }

        if(text==directionMsg[5]+",1") 
        {    
            player[0].transform.position+=new Vector3(-0.4f,0.6f,0);//プレイヤー0が左上に移動
            UpdateTileColor(player[0],playercolor[0]);
            text="";
        }


        
        if(text==directionMsg[0]+",2") 
        {    
            player[1].transform.position+=new Vector3(0.4f,0.6f,0);//プレイヤー1が右上に移動
            UpdateTileColor(player[1],playercolor[1]);
            text="";
        }

        if(text==directionMsg[1]+",2") 
        {    
            player[1].transform.position+=new Vector3(0.8f,0,0);//プレイヤー1が右に移動
            UpdateTileColor(player[1],playercolor[1]);
            text="";
        }   
        
        if(text==directionMsg[2]+",2") 
        {    
            player[1].transform.position+=new Vector3(0.4f,-0.6f,0);//プレイヤー1が右下に移動
            UpdateTileColor(player[1],playercolor[1]);
            text="";
        }
        
        if(text==directionMsg[3]+",2") 
        {    
            player[1].transform.position+=new Vector3(-0.4f,-0.6f,0);//プレイヤー1が左下に移動
            UpdateTileColor(player[1],playercolor[1]);
            text="";
        }

        if(text==directionMsg[4]+",2") 
        {    
            player[1].transform.position+=new Vector3(-0.8f,0,0);//プレイヤー1が左に移動
            UpdateTileColor(player[1],playercolor[1]);
            text="";
        }

        if(text==directionMsg[5]+",2") 
        {    
            player[1].transform.position+=new Vector3(-0.4f,0.6f,0);//プレイヤー1が左上に移動
            UpdateTileColor(player[1],playercolor[1]);
            text="";
        }



        if(text==directionMsg[0]+",3") 
        {    
            player[2].transform.position+=new Vector3(0.4f,0.6f,0);//プレイヤー2が右上に移動
            UpdateTileColor(player[2],playercolor[2]);
            text="";
        }

        if(text==directionMsg[1]+",3") 
        {    
            player[2].transform.position+=new Vector3(0.8f,0,0);//プレイヤー2が右に移動
            UpdateTileColor(player[0],playercolor[2]);
            text="";
        }   
        
        if(text==directionMsg[2]+",3") 
        {    
            player[2].transform.position+=new Vector3(0.4f,-0.6f,0);//プレイヤー2が右下に移動
            UpdateTileColor(player[2],playercolor[2]);
            text="";
        }
        
        if(text==directionMsg[3]+",3") 
        {    
            player[2].transform.position+=new Vector3(-0.4f,-0.6f,0);//プレイヤー2が左下に移動
            UpdateTileColor(player[2],playercolor[2]);
            text="";
        }

        if(text==directionMsg[4]+",3") 
        {    
            player[2].transform.position+=new Vector3(-0.8f,0,0);//プレイヤー2が左に移動
            UpdateTileColor(player[2],playercolor[2]);
            text="";
        }

        if(text==directionMsg[5]+",3") 
        {    
            player[2].transform.position+=new Vector3(-0.4f,0.6f,0);//プレイヤー2が左上に移動
            UpdateTileColor(player[2],playercolor[2]);
            text="";
        }
            
    }

    public void ReceivTest(string message)
    {   
        text=message;
        Debug.Log(text);        
    }

    public void UpdateTileColor(GameObject player,Color playercolor)
    {   //var tilemap = GetComponent<Tilemap>();//Tilemapを取得
        Vector3Int currentPlayerTile = Tilemap.WorldToCell(player.transform.position);//現在いるTileの座標を取得
        Tilemap.SetTileFlags(currentPlayerTile, TileFlags.None);//Tileのフラグをtrueに
        Tilemap.SetColor( currentPlayerTile, playercolor );//Tileのcolorをplayercolorに変更
        //Debug.Log(playercolor);
    }

    
}
