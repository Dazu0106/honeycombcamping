using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.Tilemaps;

public class Server : MonoBehaviour {
    private int count = 0; // click counter
    public WebSocket ws;
    public GameObject player2,player3,player4;
    public Tilemap Tilemap;
    private Color player2color,player3color,player4color;
    private string text="";


   
    void Awake ()
        {   
            player2color = Color.blue;
            player3color = Color.green;
            player4color = Color.yellow;

            UpdateTileColor(player2,player2color);
            UpdateTileColor(player3,player3color);
            UpdateTileColor(player4,player4color);
        }


    void Start () {
        var url = "ws://localhost:8080";
        ws = new WebSocket(url);
        ws.Connect();
        ws.OnMessage += (sender , e) => ReceivTest(e.Data) ;

    }
    void Update () {
       if(text!="") 
       {
           
            player2.transform.position+=new Vector3(0.8f,0,0);
            player3.transform.position+=new Vector3(-0.4f,-0.6f);
            player4.transform.position+=new Vector3(-0.4f,0.6f);
            
            UpdateTileColor(player2,player2color);
            UpdateTileColor(player3,player3color);
            UpdateTileColor(player4,player4color);
            text="";
           
       }

        

        if (Input.GetMouseButtonDown(0))
        {
            
            Debug.Log("clicked!");
            count++;
            //ws.Send("clicked No. " + 
            ws.Send(count.ToString());
        }
    }

    public void ReceivTest(string message)
    {   text=message;
        
        
        
        Debug.Log(text) ;
    }

    public void UpdateTileColor(GameObject player,Color playercolor)
    {   //var tilemap = GetComponent<Tilemap>();//Tilemapを取得
        Vector3Int currentPlayerTile = Tilemap.WorldToCell(player.transform.position);//現在いるTileの座標を取得
        Tilemap.SetTileFlags(currentPlayerTile, TileFlags.None);//Tileのフラグをtrueに
        Tilemap.SetColor( currentPlayerTile, playercolor );//Tileのcolorをplayercolorに変更
        print(playercolor);
    }
}