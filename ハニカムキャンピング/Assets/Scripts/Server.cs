
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.Tilemaps;

public class Server : MonoBehaviour {
    public WebSocket ws;
    public Tilemap Tilemap;
    public GameObject[] dummyPlayer = new GameObject[3];
    private GameObject[] player = new GameObject[4];
    private Queue<string> texts = new Queue<string>();
    private string[] directionMsg = {"Rfront","Right","Rback","Lback","Left","Lfront"};

    　
    
   
    void Awake ()
        {  
        }


    void Start () {
        
        var url = "ws://172.16.98.82:8080";//"ws://localhost:8080";
        ws = new WebSocket(url);
        ws.Connect();
        ws.OnMessage += (sender , e) => ReceivTest(e.Data) ;
        player[0] = GameObject.Find("Bullet0");
        player[1] = GameObject.Find("Bullet1");
        player[2] = GameObject.Find("Bullet2");
        player[3] = GameObject.Find("Bullet3");


        for (int i = 0; i < player.Length; i++)
        {   //player[i] = GameObject.Find("Bullet"+i);
            UpdateTileColor(player[i],player[i].GetComponent<MovementController>().tileColor);
        }
        

    }
    void Update () {
        if(texts.Count>0){
            string text=texts.Dequeue();
            //Debug.Log("On message:"+text);
            if((dummyPlayer[0]==player[0]) || (dummyPlayer[1]==player[0]) || (dummyPlayer[2]==player[0]))//dummyplayerがplayer0であるをチェック
            {
                //Debug.Log("0:"+text);
            
                if(text==(directionMsg[0]+",0")) 
                {    
                    player[0].transform.position+=new Vector3(0.4f,0.6f,0);//プレイヤー0が右上に移動
                    UpdateTileColor(player[0],player[0].GetComponent<MovementController>().tileColor);
                    
                }
            

                if(text==(directionMsg[1]+",0")) 
                {    
                    player[0].transform.position+=new Vector3(0.8f,0,0);//プレイヤー0が右に移動
                    UpdateTileColor(player[0],player[0].GetComponent<MovementController>().tileColor);
                    
                }   
                
                if(text==(directionMsg[2]+",0")) 
                {    
                    player[0].transform.position+=new Vector3(0.4f,-0.6f,0);//プレイヤー0が右下に移動
                    UpdateTileColor(player[0],player[0].GetComponent<MovementController>().tileColor);
                    
                }
                
                if(text==(directionMsg[3]+",0")) 
                {    
                    player[0].transform.position+=new Vector3(-0.4f,-0.6f,0);//プレイヤー0が左下に移動
                    UpdateTileColor(player[0],player[0].GetComponent<MovementController>().tileColor);
                    
                }

                if(text==(directionMsg[4]+",0")) 
                {    
                    player[0].transform.position+=new Vector3(-0.8f,0,0);//プレイヤー0が左に移動
                    UpdateTileColor(player[0],player[0].GetComponent<MovementController>().tileColor);
                    
                }

                if(text==(directionMsg[5]+",0")) 
                {    
                    player[0].transform.position+=new Vector3(-0.4f,0.6f,0);//プレイヤー0が左上に移動
                    UpdateTileColor(player[0],player[0].GetComponent<MovementController>().tileColor);
                    
                }
            }


            if((dummyPlayer[0]==player[1]) || (dummyPlayer[1]==player[1]) || (dummyPlayer[2]==player[1]))
            {
                //Debug.Log("1:"+text);
                if(text==(directionMsg[0]+",1")) 
                {    
                    player[1].transform.position+=new Vector3(0.4f,0.6f,0);//プレイヤー1が右上に移動
                    UpdateTileColor(player[1],player[1].GetComponent<MovementController>().tileColor);
                    
                }

                if(text==(directionMsg[1]+",1")) 
                {    
                    player[1].transform.position+=new Vector3(0.8f,0,0);//プレイヤー1が右に移動
                    UpdateTileColor(player[1],player[1].GetComponent<MovementController>().tileColor);
                    
                }   
                
                if(text==(directionMsg[2]+",1")) 
                {    
                    player[1].transform.position+=new Vector3(0.4f,-0.6f,0);//プレイヤー1が右下に移動
                    UpdateTileColor(player[1],player[1].GetComponent<MovementController>().tileColor);
                    
                }
                
                if(text==(directionMsg[3]+",1")) 
                {    
                    player[1].transform.position+=new Vector3(-0.4f,-0.6f,0);//プレイヤー1が左下に移動
                    UpdateTileColor(player[1],player[1].GetComponent<MovementController>().tileColor);
                    
                }

                if(text==(directionMsg[4]+",1")) 
                {    
                    player[1].transform.position+=new Vector3(-0.8f,0,0);//プレイヤー1が左に移動
                    UpdateTileColor(player[1],player[1].GetComponent<MovementController>().tileColor);
                    
                }

                if(text==(directionMsg[5]+",1")) 
                {    
                    player[1].transform.position+=new Vector3(-0.4f,0.6f,0);//プレイヤー1が左上に移動
                    UpdateTileColor(player[1],player[1].GetComponent<MovementController>().tileColor);
                    
                }
            }


            if((dummyPlayer[0]==player[2]) || (dummyPlayer[1]==player[2]) || (dummyPlayer[2]==player[2]))
            {
                //Debug.Log("2:"+text);
                if(text==(directionMsg[0]+",2")) 
                {    
                    player[2].transform.position+=new Vector3(0.4f,0.6f,0);//プレイヤー2が右上に移動
                    UpdateTileColor(player[2],player[2].GetComponent<MovementController>().tileColor);
                    
                }

                if(text==(directionMsg[1]+",2")) 
                {    
                    player[2].transform.position+=new Vector3(0.8f,0,0);//プレイヤー2が右に移動
                    UpdateTileColor(player[2],player[2].GetComponent<MovementController>().tileColor);
                    
                }   
                
                if(text==(directionMsg[2]+",2")) 
                {    
                    player[2].transform.position+=new Vector3(0.4f,-0.6f,0);//プレイヤー2が右下に移動
                    UpdateTileColor(player[2],player[2].GetComponent<MovementController>().tileColor);
                    
                }
                
                if(text==(directionMsg[3]+",2")) 
                {    
                    player[2].transform.position+=new Vector3(-0.4f,-0.6f,0);//プレイヤー2が左下に移動
                    UpdateTileColor(player[2],player[2].GetComponent<MovementController>().tileColor);
                    
                }

                if(text==(directionMsg[4]+",2")) 
                {    
                    player[2].transform.position+=new Vector3(-0.8f,0,0);//プレイヤー2が左に移動
                    UpdateTileColor(player[2],player[2].GetComponent<MovementController>().tileColor);
                    
                }

                if(text==(directionMsg[5]+",2")) 
                {    
                    player[2].transform.position+=new Vector3(-0.4f,0.6f,0);//プレイヤー2が左上に移動
                    UpdateTileColor(player[2],player[2].GetComponent<MovementController>().tileColor);
                    
                }
            }


            if((dummyPlayer[0]==player[3]) || (dummyPlayer[1]==player[3]) || (dummyPlayer[2]==player[3]))
            {
                //Debug.Log("3:"+text);
                if(text==(directionMsg[0]+",3")) 
                {    
                    player[3].transform.position+=new Vector3(0.4f,0.6f,0);//プレイヤー3が右上に移動
                    UpdateTileColor(player[3],player[3].GetComponent<MovementController>().tileColor);
                    
                }

                if(text==(directionMsg[1]+",3")) 
                {    
                    player[3].transform.position+=new Vector3(0.8f,0,0);//プレイヤー3が右に移動
                    UpdateTileColor(player[3],player[3].GetComponent<MovementController>().tileColor);
                    
                }   
                
                if(text==(directionMsg[2]+",3")) 
                {    
                    player[3].transform.position+=new Vector3(0.4f,-0.6f,0);//プレイヤー3が右下に移動
                    UpdateTileColor(player[3],player[3].GetComponent<MovementController>().tileColor);
                    
                }
                
                if(text==(directionMsg[3]+",3")) 
                {    
                    player[3].transform.position+=new Vector3(-0.4f,-0.6f,0);//プレイヤー3が左下に移動
                    UpdateTileColor(player[3],player[3].GetComponent<MovementController>().tileColor);
                    
                }

                if(text==(directionMsg[4]+",3")) 
                {    
                    player[3].transform.position+=new Vector3(-0.8f,0,0);//プレイヤー3が左に移動
                    UpdateTileColor(player[3],player[3].GetComponent<MovementController>().tileColor);
                    
                }

                if(text==(directionMsg[5]+",3")) 
                {    
                    player[3].transform.position+=new Vector3(-0.4f,0.6f,0);//プレイヤー3が左上に移動
                    UpdateTileColor(player[3],player[3].GetComponent<MovementController>().tileColor);
                    
                }
            }
        }
    }

    public void ReceivTest(string message)
    {   
        //text=message;
        texts.Enqueue(message);
        Debug.Log("ReceivTest"+message);        
    }

    public void UpdateTileColor(GameObject player,Color playercolor)
    {   //var tilemap = GetComponent<Tilemap>();//Tilemapを取得
        Vector3Int currentPlayerTile = Tilemap.WorldToCell(player.transform.position);//現在いるTileの座標を取得
        Tilemap.SetTileFlags(currentPlayerTile, TileFlags.None);//Tileのフラグをtrueに
        Tilemap.SetColor( currentPlayerTile, playercolor );//Tileのcolorをplayercolorに変更
        //Debug.Log(playercolor);
    }

    
}
