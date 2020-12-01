using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.Tilemaps;

public class Server : MonoBehaviour {
    private int count = 0; // click counter
    public WebSocket ws;
    public GameObject player1,player2,player3;
    public Tilemap Tilemap;
    private Color player1color,player2color,player3color;
    private string text="";


   
    void Awake ()
        {   
            player1color = Color.blue;
            player2color = Color.green;
            player3color = Color.yellow;

            UpdateTileColor(player1,player1color);
            UpdateTileColor(player2,player2color);
            UpdateTileColor(player3,player3color);
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
           if(CheckAroundTile(player1))
            {
                player1.transform.position+=new Vector3(0.8f,0,0);
            }
            player2.transform.position+=new Vector3(-0.4f,-0.6f);
            player3.transform.position+=new Vector3(-0.4f,0.6f);
            
            UpdateTileColor(player1,player1color);
            UpdateTileColor(player2,player2color);
            UpdateTileColor(player3,player3color);
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
    public bool CheckAroundTile(GameObject player)
    {
        Vector3Int uRPos = Tilemap.WorldToCell(player.transform.position+new Vector3(0.4f,0.6f)); //右斜め上のタイルの色を取得
        Vector3Int uLPos = Tilemap.WorldToCell(player.transform.position+new Vector3(0.4f,-0.6f));//左斜め上
        Vector3Int rPos = Tilemap.WorldToCell(player.transform.position+new Vector3(0.8f,0,0));//真右
        Vector3Int lPos = Tilemap.WorldToCell(player.transform.position+new Vector3(-0.8f,0,0));//真左
        Vector3Int dRPos = Tilemap.WorldToCell(player.transform.position+new Vector3(-0.4f,0.6f)); //右斜め下
        Vector3Int dLPos = Tilemap.WorldToCell(player.transform.position+new Vector3(-0.4f,-0.6f));//左斜め下

        Color uRC=Tilemap.GetColor(uRPos);
        Color uLC=Tilemap.GetColor(uLPos);
        Color rC=Tilemap.GetColor(rPos);
        Color lC=Tilemap.GetColor(lPos);
        Color dRC=Tilemap.GetColor(dRPos);
        Color dLC=Tilemap.GetColor(dLPos);
        if((uRC==Color.white || uLC==Color.white || rC==Color.white|| lC==Color.white || dRC==Color.white || dLC==Color.white))
        {
            return true;
        }

        return false;
    }
}