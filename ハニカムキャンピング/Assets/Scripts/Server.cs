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
    public Color[] playercolor;
    Vector3Int[] pos;
    Color[] poscolor;
    private string text="";
    public bool[] settable;//右上、左上、右、左、右下、左下の順で6つ
    private bool movable;//移動可能か

   
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
        var url = /*"172.16.98.82:8080";*/"ws://localhost:8080";
        ws = new WebSocket(url);
        ws.Connect();
        ws.OnMessage += (sender , e) => ReceivTest(e.Data) ;
        movable = true;

    }
    void Update () {
       if(text=="order") 
       {
           if(movable)
            {
                player[0].transform.position+=new Vector3(0.8f,0,0);
                CheckAroundTile(player[0]);
            }
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
        print(playercolor);
    }
    public void CheckAroundTile(GameObject player)
    {   
        int length = 6;
         pos[0] = Tilemap.WorldToCell(player.transform.position+new Vector3(0.4f,0.6f)); //右斜め上のタイルの色を取得
         pos[1] = Tilemap.WorldToCell(player.transform.position+new Vector3(0.4f,-0.6f));//左斜め上
         pos[2] = Tilemap.WorldToCell(player.transform.position+new Vector3(0.8f,0,0));//真右
         pos[3] = Tilemap.WorldToCell(player.transform.position+new Vector3(-0.8f,0,0));//真左
         pos[4] = Tilemap.WorldToCell(player.transform.position+new Vector3(-0.4f,0.6f)); //右斜め下
         pos[5] = Tilemap.WorldToCell(player.transform.position+new Vector3(-0.4f,-0.6f));//左斜め下

        for (int i = 0; i < length; i++)
        {
            poscolor[i]=Tilemap.GetColor(pos[i]);
            settable[i]=false;
            if(poscolor[i]==Color.white)//タイルが白いかをチェック
            {
                settable[i]=true;
            }
        }
        

        

        if( settable[0])//どれかがtrueならば移動可能
        {
            movable = true;
            
        }


            movable = false;
    }
}