/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.Tilemaps;

public class Server : MonoBehaviour {
    private int count = 0; // click counter
    public WebSocket ws;
    public GameObject[] player;
    public Tilemap Tilemap;
    private Color[] playercolor = new Color[3];
    private string text="";

   
    void Awake ()
        {   
            playercolor[0] = Color.blue;
            playercolor[1] = Color.green;
            playercolor[2] = Color.yellow;

            UpdateTileColor(player[0],playercolor[0]);
            UpdateTileColor(player[1],playercolor[1]);
            UpdateTileColor(player[2],playercolor[2]);
            
        }


    void Start () {
        var url = "ws://localhost:8080";
        ws = new WebSocket(url);
        ws.Connect();
        ws.OnMessage += (sender , e) => ReceivTest(e.Data) ;

    }
    void Update () {
       if(text=="order") 
       {
            player[0].transform.position+=new Vector3(0.8f,0,0);
            player[1].transform.position+=new Vector3(-0.4f,-0.6f);
            player[2].transform.position+=new Vector3(-0.4f,0.6f);
            
            UpdateTileColor(player[0],playercolor[0]);
            UpdateTileColor(player[1],playercolor[1]);
            UpdateTileColor(player[2],playercolor[2]);
            text="";
            
           
       } 
       if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicked!");
            count++;
            ws.Send("order");
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
    }

    
}
*/