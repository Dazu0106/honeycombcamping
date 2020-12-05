using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class ActControllerManager : MonoBehaviour
{
    GameObject up_R, mid_R, down_R;
    GameObject up_L, mid_L, down_L;
    
    GameObject clickedButton;
    GameObject player;

    public Vector3 direction;

    private Tilemap hexTile;
    private bool[] settable = new bool[6];//右上、左上、右、左、右下、左下の順で6つ
    private bool movable;//移動可能か


    // Start is called before the first frame update
    void Start()
    {   
        up_R = GameObject.Find("Right up");
        mid_R = GameObject.Find("Right middle");
        down_R = GameObject.Find("Right down");

        up_L = GameObject.Find("Left up");
        mid_L = GameObject.Find("Left middle");
        down_L = GameObject.Find("Left down");

        player = GameObject.Find("Bullet");
        hexTile = player.GetComponent<MovementController>().Tilemap;

        CheckAroundTile();
    }

    // Update is called once per frame
    void Update()
    {
        if(movable){
            
            if(Input.GetMouseButtonDown(0)){
                clickedButton = null;

                // ClickedSprites check
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
    
                if (hit2d) {
                    clickedButton = hit2d.transform.gameObject;
                } 

                // 右上
                if(clickedButton == up_R&&settable[0]){
                    CheckAroundTile();
                    //Debug.Log("Moved right up");
                    //Debug.Log("settable[0]"+settable[0]);
                    direction = new Vector3(0.4f,0.6f);
                    player.GetComponent<MovementController>().transform.position += direction;
                    player.GetComponent<MovementController>().UpdatePosition();
                    CheckAroundTile();
                    
                }
                
                // 右
                if(clickedButton == mid_R&&settable[2]){
                    CheckAroundTile();
                    //Debug.Log("Moved right middle");
                    //Debug.Log("settable[2]"+settable[2]);
                    direction = new Vector3(0.8f,0,0);
                    player.GetComponent<MovementController>().transform.position += direction;
                    player.GetComponent<MovementController>().UpdatePosition();
                    CheckAroundTile();
                    
                }

                // 右下
                if(clickedButton == down_R&&settable[4]){
                    CheckAroundTile();
                    //Debug.Log("Moved right down");
                    //Debug.Log("settable[4]"+settable[4]);
                    direction = new Vector3(0.4f,-0.6f);
                    player.GetComponent<MovementController>().transform.position += direction;
                    player.GetComponent<MovementController>().UpdatePosition();
                    CheckAroundTile();
                    
                }

                // 左上
                if(clickedButton == up_L&&settable[1]){
                    CheckAroundTile();
                    //Debug.Log("Moved left up");
                    //Debug.Log("settable[1]"+settable[1]);
                    direction = new Vector3(-0.4f,0.6f);
                    player.GetComponent<MovementController>().transform.position += direction;
                    player.GetComponent<MovementController>().UpdatePosition();
                    CheckAroundTile();
                    
                }

                // 左
                if(clickedButton == mid_L&&settable[3]){
                    CheckAroundTile();
                    //Debug.Log("Moved left middle");
                    //Debug.Log("settable[3]"+settable[3]);
                    direction = new Vector3(-0.8f,0,0);
                    player.GetComponent<MovementController>().transform.position += direction;
                    player.GetComponent<MovementController>().UpdatePosition();
                    CheckAroundTile();
                }

                // 左下
                if(clickedButton == down_L&&settable[5]){
                    CheckAroundTile();
                    //Debug.Log("Moved left down");
                   // Debug.Log("settable[5]"+settable[5]);
                    direction = new Vector3(-0.4f,-0.6f);
                    player.GetComponent<MovementController>().transform.position += direction;
                    player.GetComponent<MovementController>().UpdatePosition();
                    CheckAroundTile();
                }

            }

        }
    }
    public void CheckAroundTile()
    {   
        Vector3Int[] pos = new Vector3Int[6];
        Color[] poscolor = new Color[6] ;
        int length = 6;
         pos[0] = hexTile.WorldToCell(player.GetComponent<MovementController>().transform.position+new Vector3(0.4f,0.6f)); //右斜め上のタイルの色を取得
         pos[1] = hexTile.WorldToCell(player.GetComponent<MovementController>().transform.position+new Vector3(0.4f,-0.6f));//左斜め上
         pos[2] = hexTile.WorldToCell(player.GetComponent<MovementController>().transform.position+new Vector3(0.8f,0,0));//真右
         pos[3] = hexTile.WorldToCell(player.GetComponent<MovementController>().transform.position+new Vector3(-0.8f,0,0));//真左
         pos[4] = hexTile.WorldToCell(player.GetComponent<MovementController>().transform.position+new Vector3(-0.4f,0.6f)); //右斜め下
         pos[5] = hexTile.WorldToCell(player.GetComponent<MovementController>().transform.position+new Vector3(-0.4f,-0.6f));//左斜め下

        for (int i = 0; i < length; i++)
        {   
            //Debug.Log("pos"+i+"="+pos[i]);
            poscolor[i]=hexTile.GetColor(pos[i]);
            //Debug.Log(poscolor[i]);
            settable[i]=false;
            if(poscolor[i]==Color.white)//タイルが白いかをチェック
            {
                settable[i]=true;
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

            
    }




}


