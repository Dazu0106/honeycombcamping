using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class ActControllerManager : MonoBehaviour
{
    
    
    GameObject clickedButton;
    public GameObject player;
    public GameObject up_R, mid_R, down_R;
    public GameObject up_L, mid_L, down_L;
    public GameObject timer;
    
    private WebSocket ws;
    private Vector3 direction;
    private Tilemap hexTile;
    
    private bool[] settable = new bool[6];//右上、左上、右、左、右下、左下の順で6つ
    private bool movable;//移動可能か
    private string playerNum;//プレイヤーの識別番号
    private string resultTx="";
    private string text="";
    private int count=0;
    private bool turnFlag;
    // Start is called before the first frame update
    void Start()
    {   

        var url = "ws://localhost:8080";//"ws://172.16.98.82:8080";
        ws = new WebSocket(url);
        ws.Connect();
        ws.OnMessage += (sender , e) => ReceivTest(e.Data) ;
        hexTile = player.GetComponent<MovementController>().Tilemap;
        playerNum = player.name.Substring(6,1);//Bulletの識別番号を取得
        //Debug.Log(playerNum);
        movable = false;
        turnFlag = timer.GetComponent<Timer>().TurnFlag;
    }

    // Update is called once per frame
    void Update()
    {   if(text=="Start,"+playerNum)
        {   
            CheckAroundTile();
            if(movable)
            {
                if(turnFlag==true)
                {
                    if(Input.GetMouseButtonDown(0)){
                        
                        clickedButton = null;

                        // ClickedSprites check
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
            
                        if (hit2d) {
                            clickedButton = hit2d.transform.gameObject;
                        } 

                        // 右上
                        if(clickedButton == up_R){
                            CheckAroundTile();
                            if(settable[0]){
                            
                                //Debug.Log("Moved right up");
                                //Debug.Log("settable[0]"+settable[0]);
                                direction = new Vector3(0.4f,0.6f);
                                player.GetComponent<MovementController>().transform.position += direction;
                                player.GetComponent<MovementController>().UpdatePosition();
                                resultTx="TurnEnd,"+"Rfront";
                            }
                            CheckAroundTile();
                            
                        }
                        
                        // 右
                        if(clickedButton == mid_R){
                            CheckAroundTile();
                            if(settable[2]){
                                //Debug.Log("Moved right middle");
                                //Debug.Log("settable[2]"+settable[2]);
                                direction = new Vector3(0.8f,0,0);
                                player.GetComponent<MovementController>().transform.position += direction;
                                player.GetComponent<MovementController>().UpdatePosition();
                                resultTx="TurnEnd,"+"Right";
                            }
                            CheckAroundTile();
                            
                        }

                        // 右下
                        if(clickedButton == down_R){
                            CheckAroundTile();
                            if(settable[4]){
                                //Debug.Log("Moved right down");
                                //Debug.Log("settable[4]"+settable[4]);
                                direction = new Vector3(0.4f,-0.6f);
                                player.GetComponent<MovementController>().transform.position += direction;
                                player.GetComponent<MovementController>().UpdatePosition();
                                resultTx="TurnEnd,"+"Rback";
                            }
                            CheckAroundTile();
                                //Debug.Log("settable[4]"+settable[4]);
                            
                            
                        }

                        // 左上
                        if(clickedButton == up_L){
                            CheckAroundTile();
                            if(settable[1]){
                                // Debug.Log("Moved left up"); 
                                //Debug.Log("settable[1]"+settable[1]);
                                direction = new Vector3(-0.4f,0.6f);
                                player.GetComponent<MovementController>().transform.position += direction;
                                player.GetComponent<MovementController>().UpdatePosition();
                                resultTx="TurnEnd,"+"Lfront";
                            }
                            CheckAroundTile();
                                //Debug.Log("settable[1]"+settable[1]);
                            
                            
                        }

                        // 左
                        if(clickedButton == mid_L){
                            CheckAroundTile();
                            if(settable[3]){
                                //Debug.Log("Moved left middle");
                                //Debug.Log("settable[3]"+settable[3]);
                                direction = new Vector3(-0.8f,0,0);
                                player.GetComponent<MovementController>().transform.position += direction;
                                player.GetComponent<MovementController>().UpdatePosition();
                                resultTx="TurnEnd,"+"Left";
                            }
                            CheckAroundTile();
                        }

                        // 左下
                        if(clickedButton == down_L){
                            CheckAroundTile();
                            if(settable[5]){
                                //Debug.Log("Moved left down");
                                // Debug.Log("settable[5]"+settable[5]);
                                direction = new Vector3(-0.4f,-0.6f);
                                player.GetComponent<MovementController>().transform.position += direction;
                                player.GetComponent<MovementController>().UpdatePosition();
                                resultTx="TurnEnd,"+"Lback";
                            }
                            CheckAroundTile();
                        }
                        
                        if(movable)
                        {
                            ws.Send(resultTx);
                        }
                        else
                        {
                            ws.Send(resultTx+"Stop");
                        }
                        movable=false;
                    }
                }
            }
            else if(count==0)
            {
                ws.Send("cantMove");
                count++;
            }
            
        }
        
    }
    public void CheckAroundTile()
    {   
        Vector3Int[] pos = new Vector3Int[6];
        TileBase[] movableTile = new TileBase[6];
        Color[] poscolor = new Color[6] ;
        Vector3Int unmovableTilePos= hexTile.WorldToCell(new Vector3(-6.35f,-4.8f));

        TileBase unmovableTile =hexTile.GetTile(unmovableTilePos);
        int length = 6;
         pos[0] = hexTile.WorldToCell(player.GetComponent<MovementController>().transform.position+new Vector3(0.4f,0.6f)); //右斜め上のタイルの色を取得
         pos[1] = hexTile.WorldToCell(player.GetComponent<MovementController>().transform.position+new Vector3(-0.4f,0.6f));//左斜め上
         pos[2] = hexTile.WorldToCell(player.GetComponent<MovementController>().transform.position+new Vector3(0.8f,0,0));//真右
         pos[3] = hexTile.WorldToCell(player.GetComponent<MovementController>().transform.position+new Vector3(-0.8f,0,0));//真左
         pos[4] = hexTile.WorldToCell(player.GetComponent<MovementController>().transform.position+new Vector3(0.4f,-0.6f)); //右斜め下
         pos[5] = hexTile.WorldToCell(player.GetComponent<MovementController>().transform.position+new Vector3(-0.4f,-0.6f));//左斜め下

        for (int i = 0; i < length; i++)
        {   
            //Debug.Log("pos"+i+"="+pos[i]);
            poscolor[i]=hexTile.GetColor(pos[i]);
            movableTile[i]=hexTile.GetTile(pos[i]);
            settable[i]=false;
            //Debug.Log("movableTile"+i+"="+hexTile.GetTile(pos[i]));
            if(poscolor[i]==Color.white)//タイルが白いかをチェック
            {
                if(movableTile[i]!=unmovableTile)//タイルが移動可能なものかをチェック
                {
                    settable[i]=true;
                }
                //Debug.Log("settable"+i+"="+settable[i]);
            }
        }
        

        

        if( settable[0] || settable[1] || settable[2] || settable[3] ||settable[4] || settable[5])//どれかがtrueならば移動可能
        {
            movable = true;
            
        }
        else
        {
            movable = false;
        }
        //Debug.Log("unmovableTile="+unmovableTile);
            
    }


        public void ReceivTest(string message)
    {   
        text=message;
        //Debug.Log(text);        
    }


}


