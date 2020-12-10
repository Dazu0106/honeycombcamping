using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using System;
using UnityEngine.UI;

public class ActScoreManager : MonoBehaviour
{
    public WebSocket ws;
    public GameObject score_object1=null;
    public GameObject score_object2=null;
    public GameObject score_object3=null;
    public GameObject score_object4=null;
    // Start is called before the first frame update
    void Start(){
        var url = "ws://172.16.98.82:8080";
        ws = new WebSocket(url);
        ws.Connect();
        ws.OnMessage += (sender , e) => ReceivTest(e.Data) ;

    }
    public string text;
    public string message;
    public string s1;
    public string s2;
    public int u;
    public int w;
    public int x;
    public int y;
    public int z;
    void ExecuteSort(){
        int[] player;       //プレイヤーの定義
        player=new int[4];
        player[0]=26;       //サーバからの値を格納
        player[1]=40;
        player[2]=19;
        player[3]=50;
        
        if(text=="resultch")


        int u=int.Parse(s1);
        if(u==0){
            int w=int.Parse(s2);
            player[0]=w;
        }else if(u==1){
            int x=int.Parse(s2);
            player[1]=x;
        }else if(u==2){
            int y=int.Parse(s2);
            player[2]=y;
        }else if(u==3){
            int z=int.Parse(s2);
            player[3]=z;
        }






        /*player[0]=26;       //サーバからの値を格納
        player[1]=40;
        player[2]=19;
        player[3]=50;*/

        int a=player[0];    //ソートする前に値を保存
        int b=player[1];
        int c=player[2];
        int d=player[3];
       
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
        
        int e=a;        //ソートする前に保存した値を別の場所にも保存
        int f=b;
        int g=c;
        int h=d; 

        Text score_text1 = score_object1.GetComponent<Text> ();
        Text score_text2 = score_object2.GetComponent<Text> ();
        Text score_text3 = score_object3.GetComponent<Text> ();
        Text score_text4 = score_object4.GetComponent<Text> ();

        if(e==player[3]){　　　　//243行目まででソートした値とプレイヤー名を一致させる
            player[3]=e;
            score_text1.text = "player0 "+player[3];
            if(f==player[2]){
                player[2]=f;
                score_text2.text = "player1 "+player[2];
                if(g==player[1]){
                    player[1]=g;
                    player[0]=h;
                    score_text3.text = "player2 "+player[1];
                    score_text4.text = "player3 "+player[0];
                    
                }else if(h==player[1]){
                    player[1]=h;
                    player[0]=g;
                    score_text3.text = "player3 "+player[1];
                    score_text4.text = "player2 "+player[0];
                }
            }else if(g==player[2]){
                player[2]=g;
                score_text2.text = "player2 "+player[2];
                if(h==player[1]){
                    player[1]=h;
                    player[0]=f;
                    score_text3.text = "player3 "+player[1];
                    score_text4.text = "player1 "+player[0];
                }else if(f==player[1]){
                    player[0]=h;
                    player[1]=f;
                    score_text3.text = "player1 "+player[1];
                    score_text4.text = "player3 "+player[0];
                }
            }else if(h==player[2]){
                player[2]=h;
                score_text2.text = "player3 "+player[2];
                if(f==player[1]){
                    player[1]=f;
                    player[0]=g;
                    score_text3.text = "player1 "+player[1];
                    score_text4.text = "player2 "+player[0];
                }else if(g==player[1]){
                    player[1]=g;
                    player[0]=f;
                    score_text3.text = "player2 "+player[1];
                    score_text4.text = "player1 "+player[0];
                }
            }
        }else if(f==player[3]){
            player[3]=f;
            score_text1.text = "player1 "+player[3];
            if(g==player[2]){
                player[2]=g;
                score_text2.text = "player2 "+player[2];
                if(h==player[1]){
                    player[1]=h;
                    player[0]=e;
                    score_text3.text = "player3 "+player[1];
                    score_text4.text = "player0 "+player[0];
                }else if(e==player[1]){
                    player[1]=e;
                    player[0]=h;
                    score_text3.text = "player0 "+player[1];
                    score_text4.text = "player3 "+player[0];
                }
            }else if(h==player[2]){
                player[2]=h;
                score_text2.text = "player3 "+player[2];
                if(e==player[1]){
                    player[1]=e;
                    player[0]=g;
                    score_text3.text = "player0 "+player[1];
                    score_text4.text = "player2 "+player[0];
                }else if(g==player[1]){
                    player[0]=e;
                    player[1]=g;
                    score_text3.text = "player2 "+player[1];
                    score_text4.text = "player0 "+player[0];
                }
            }else if(e==player[2]){
                player[2]=e;
                score_text2.text = "player0 "+player[2];
                if(g==player[1]){
                    player[1]=g;
                    player[0]=h;
                    score_text3.text = "player2 "+player[1];
                    score_text4.text = "player3 "+player[0];
                }else if(h==player[1]){
                    player[1]=h;
                    player[0]=g;
                    score_text3.text = "player3 "+player[1];
                    score_text4.text = "player2 "+player[0];
                }
            }
        }else if(g==player[3]){
            player[3]=g;
            score_text1.text = "player2 "+player[3];
            if(f==player[2]){
                player[2]=f;
                score_text2.text = "player1 "+player[2];
                if(e==player[1]){
                    player[1]=e;
                    player[0]=h;
                    score_text3.text = "player0 "+player[1];
                    score_text4.text = "player3 "+player[0];
                }else if(h==player[1]){
                    player[0]=e;
                    player[1]=h;
                    score_text3.text = "player3 "+player[1];
                    score_text4.text = "player0 "+player[0];
                }
            }else if(e==player[2]){
                player[2]=e;
                score_text2.text = "player0 "+player[2];
                if(h==player[1]){
                    player[1]=h;
                    player[0]=f;
                    score_text3.text = "player3 "+player[1];
                    score_text4.text = "player1 "+player[0];
                }else if(f==player[1]){
                    player[0]=h;
                    player[1]=f;
                    score_text3.text = "player1 "+player[1];
                    score_text4.text = "player3 "+player[0];
                }
            }else if(h==player[2]){
                player[2]=h;
                score_text2.text = "player3 "+player[2];
                if(f==player[1]){
                    player[1]=f;
                    player[0]=e;
                    score_text3.text = "player1 "+player[1];
                    score_text4.text = "player0 "+player[0];
                }else if(e==player[1]){
                    player[1]=e;
                    player[0]=f;
                    score_text3.text = "player0 "+player[1];
                    score_text4.text = "player1 "+player[0];
                }
            }
        }else if(h==player[3]){
            player[3]=h;
            score_text1.text = "player3 "+player[3];
            if(e==player[2]){
                player[2]=e;
                score_text2.text = "player0 "+player[2];
                if(g==player[1]){
                    player[1]=g;
                    player[0]=f;
                    score_text3.text = "player2 "+player[1];
                    score_text4.text = "player1 "+player[0];
                }else if(f==player[1]){
                    player[0]=g;
                    player[1]=f;
                    score_text3.text = "player1 "+player[1];
                    score_text4.text = "player2 "+player[0];
                }
            }else if(f==player[2]){
                player[2]=f;
                score_text2.text = "player1 "+player[2];
                if(g==player[1]){
                    player[1]=g;
                    player[0]=e;
                    score_text3.text = "player2 "+player[1];
                    score_text4.text = "player0 "+player[0];
                }else if(e==player[1]){
                    player[0]=g;
                    player[1]=e;
                    score_text3.text = "player0 "+player[1];
                    score_text4.text = "player2 "+player[0];
                }
            }else if(g==player[2]){
                player[2]=g;
                score_text2.text = "player2 "+player[2];
                if(f==player[1]){
                    player[1]=f;
                    player[0]=e;
                    score_text3.text = "player1 "+player[1];
                    score_text4.text = "player0 "+player[0];
                }else if(e==player[1]){
                    player[1]=e;
                    player[0]=f;
                    score_text3.text = "player0 "+player[1];
                    score_text4.text = "player1 "+player[0];
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        string s= message;
        string s1=s.Substring(0,1);
        string s2=s.Substring(1,2);
        if(Input.GetKey(KeyCode.A)){
        ExecuteSort();　　　//関数呼び出し
        }
        

    }

    public void ReceivTest(string message)
    {   
        text=message;
    }
}
