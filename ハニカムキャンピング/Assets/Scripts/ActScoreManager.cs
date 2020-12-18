using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement ;

public class ActScoreManager : MonoBehaviour
{
    public WebSocket ws;
    public GameObject score_object1=null;
    public GameObject score_object2=null;
    public GameObject score_object3=null;
    public GameObject score_object4=null;
    public GameObject Panel ;

    public string text = "testtest";
    public string message = "testtest";
    public int[] player = new int[4];
    public string[] DirectionCheck = new string[6]  ;
    public bool ScoreAdd ;
    // Start is called before the first frame update
    void Start(){

        Panel.SetActive(false) ;

        var url = "ws://172.16.98.82:8080";
        ws = new WebSocket(url);
        ws.Connect();
        ws.OnMessage += (sender , e) => ReceivTest(e.Data) ;
        player[0]=0;//プレイヤーの初期値を0に設定       
        player[1]=0;
        player[2]=0;
        player[3]=0;

        DirectionCheck[0] = "Rfront" ;
        DirectionCheck[1] = "Right" ;
        DirectionCheck[2] = "Rback" ;
        DirectionCheck[3] = "Lback" ;
        DirectionCheck[4] = "Left" ;
        DirectionCheck[5] = "Lfront" ;

        ScoreAdd = false;  
    }

    void ExecuteSort(){
        int e=player[0];    //ソートする前に値を保存
        int f=player[1];
        int g=player[2];
        int h=player[3];

        // バブルソートで配列の中身を昇順で並べ替えます。
        for (int i = 0; i < player.Length; i++){

            // 要素の比較を行います。最後の要素は外側のループが終了するごとに確定します。
            for (int j = 1; j < player.Length - i; j++){
                
                
                // 隣り合う要素と比較し、順序が逆であれば入れ替えます。
                if (player[j] < player[j - 1]){

                    // 配列の要素の交換を行います。
                    int temp = player[j];
                    player[j] = player[j - 1];
                    player[j - 1] = temp;
                }
            }
        }

        Text score_text1 = score_object1.GetComponent<Text> ();
        Text score_text2 = score_object2.GetComponent<Text> ();
        Text score_text3 = score_object3.GetComponent<Text> ();
        Text score_text4 = score_object4.GetComponent<Text> ();

        if(e==player[3]){　　　　//256行目まででソートした値とプレイヤー名を一致させる
            player[3]=e;
            score_text1.text = "Player0 "+player[3];
            if(f==player[2]){
                player[2]=f;
                score_text2.text = "Player1 "+player[2];
                if(g==player[1]){
                    player[1]=g;
                    player[0]=h;
                    score_text3.text = "Player2 "+player[1];
                    score_text4.text = "Player3 "+player[0];
                }else if(h==player[1]){
                    player[1]=h;
                    player[0]=g;
                    score_text3.text = "Player3 "+player[1];
                    score_text4.text = "Player2 "+player[0];
                }
            }else if(g==player[2]){
                player[2]=g;
                score_text2.text = "Player2 "+player[2];
                if(h==player[1]){
                    player[1]=h;
                    player[0]=f;
                    score_text3.text = "Player3 "+player[1];
                    score_text4.text = "Player1 "+player[0];
                }else if(f==player[1]){
                    player[0]=h;
                    player[1]=f;
                    score_text3.text = "player1 "+player[1];
                    score_text4.text = "Player3 "+player[0];
                }
            }else if(h==player[2]){
                player[2]=h;
                score_text2.text = "Player3 "+player[2];
                if(f==player[1]){
                    player[1]=f;
                    player[0]=g;
                    score_text3.text = "Player1 "+player[1];
                    score_text4.text = "Player2 "+player[0];
                }else if(g==player[1]){
                    player[1]=g;
                    player[0]=f;
                    score_text3.text = "Player2 "+player[1];
                    score_text4.text = "Player1 "+player[0];
                }
            }
        }else if(f==player[3]){
            player[3]=f;
            score_text1.text = "Player1 "+player[3];
            if(g==player[2]){
                player[2]=g;
                score_text2.text = "Player2 "+player[2];
                if(h==player[1]){
                    player[1]=h;
                    player[0]=e;
                    score_text3.text = "Player3 "+player[1];
                    score_text4.text = "Player0 "+player[0];
                }else if(e==player[1]){
                    player[1]=e;
                    player[0]=h;
                    score_text3.text = "Player0 "+player[1];
                    score_text4.text = "Player3 "+player[0];
                }
            }else if(h==player[2]){
                player[2]=h;
                score_text2.text = "Player3 "+player[2];
                if(e==player[1]){
                    player[1]=e;
                    player[0]=g;
                    score_text3.text = "Player0 "+player[1];
                    score_text4.text = "Player2 "+player[0];
                }else if(g==player[1]){
                    player[0]=e;
                    player[1]=g;
                    score_text3.text = "Player2 "+player[1];
                    score_text4.text = "Player0 "+player[0];
                }
            }else if(e==player[2]){
                player[2]=e;
                score_text2.text = "Player0 "+player[2];
                if(g==player[1]){
                    player[1]=g;
                    player[0]=h;
                    score_text3.text = "Player2 "+player[1];
                    score_text4.text = "Player3 "+player[0];
                }else if(h==player[1]){
                    player[1]=h;
                    player[0]=g;
                    score_text3.text = "Player3 "+player[1];
                    score_text4.text = "Player2 "+player[0];
                }
            }
        }else if(g==player[3]){
            player[3]=g;
            score_text1.text = "Player2 "+player[3];
            if(f==player[2]){
                player[2]=f;
                score_text2.text = "Player1 "+player[2];
                if(e==player[1]){
                    player[1]=e;
                    player[0]=h;
                    score_text3.text = "Player0 "+player[1];
                    score_text4.text = "Player3 "+player[0];
                }else if(h==player[1]){
                    player[0]=e;
                    player[1]=h;
                    score_text3.text = "Player3 "+player[1];
                    score_text4.text = "Player0 "+player[0];
                }
            }else if(e==player[2]){
                player[2]=e;
                score_text2.text = "Player0 "+player[2];
                if(h==player[1]){
                    player[1]=h;
                    player[0]=f;
                    score_text3.text = "Player3 "+player[1];
                    score_text4.text = "Player1 "+player[0];
                }else if(f==player[1]){
                    player[0]=h;
                    player[1]=f;
                    score_text3.text = "Player1 "+player[1];
                    score_text4.text = "Player3 "+player[0];
                }
            }else if(h==player[2]){
                player[2]=h;
                score_text2.text = "Player3 "+player[2];
                if(f==player[1]){
                    player[1]=f;
                    player[0]=e;
                    score_text3.text = "Player1 "+player[1];
                    score_text4.text = "Player0 "+player[0];
                }else if(e==player[1]){
                    player[1]=e;
                    player[0]=f;
                    score_text3.text = "Player0 "+player[1];
                    score_text4.text = "Player1 "+player[0];
                }
            }
        }else if(h==player[3]){
            player[3]=h;
            score_text1.text = "Player3 "+player[3];
            if(e==player[2]){
                player[2]=e;
                score_text2.text = "Player0 "+player[2];
                if(g==player[1]){
                    player[1]=g;
                    player[0]=f;
                    score_text3.text = "Player2 "+player[1];
                    score_text4.text = "Player1 "+player[0];
                }else if(f==player[1]){
                    player[0]=g;
                    player[1]=f;
                    score_text3.text = "Player1 "+player[1];
                    score_text4.text = "Player2 "+player[0];
                }
            }else if(f==player[2]){
                player[2]=f;
                score_text2.text = "Player1 "+player[2];
                if(g==player[1]){
                    player[1]=g;
                    player[0]=e;
                    score_text3.text = "Player2 "+player[1];
                    score_text4.text = "Player0 "+player[0];
                }else if(e==player[1]){
                    player[0]=g;
                    player[1]=e;
                    score_text3.text = "Player0 "+player[1];
                    score_text4.text = "Player2 "+player[0];
                }
            }else if(g==player[2]){
                player[2]=g;
                score_text2.text = "Player2 "+player[2];
                if(f==player[1]){
                    player[1]=f;
                    player[0]=e;
                    score_text3.text = "Player1 "+player[1];
                    score_text4.text = "Player0 "+player[0];
                }else if(e==player[1]){
                    player[1]=e;
                    player[0]=f;
                    score_text3.text = "Player0 "+player[1];
                    score_text4.text = "Player1 "+player[0];
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(text.Contains("resultcheck")){
            int playernumber = -1 ;
            playernumber = int.Parse(text.Substring(11));
            ws.Send("result" + player[playernumber]) ;
            text = "testtest" ;
        }

        if(text=="GameSet"){

            Panel.SetActive(true) ;
            ExecuteSort();
            text="testtest";

        }
    }

    public void ReceivTest(string message)
    {   
        //int playernumber = -1 ;
        text=message;
        for(int i = 0 ; i < 6 ; i++)
        {
            if(text.Contains(DirectionCheck[i]))
            {
                ScoreAdd = true ;
            }
        }

        if(ScoreAdd == true)
        {
            if(text.Contains("0"))
            {
                player[0] += 1 ;
            }
            else if(text.Contains("1"))
            {
                player[1] += 1 ;
            }
            else if(text.Contains("2"))
            {
                player[2] += 1 ;
            }
            else if(text.Contains("3"))
            {
                player[3] += 1 ;
            }

            ScoreAdd = false ;
        }


        if(text == "GameRestart")
        {
            SceneManager.LoadScene("Scene_Game") ;
        }

    }
}
