using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using System;

public class result : MonoBehaviour
{
    public WebSocket ws;
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
    void ExecuteSort(){
        int[] player;       //プレイヤーの定義
        player=new int[4];　

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






        /*player[0]=19;       //サーバからの値を格納
        player[1]=26;
        player[2]=40;
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
        
        if(e==player[3]){　　　　//243行目まででソートした値とプレイヤー名を一致させる
            player[3]=e;
            Debug.Log("player0 "+player[3]);
            if(f==player[2]){
                player[2]=f;
                Debug.Log("player1 "+player[2]);
                if(g==player[1]){
                    player[1]=g;
                    player[0]=h;
                    Debug.Log("player2 "+player[1]);
                    Debug.Log("player3 "+player[0]);
                }else if(h==player[1]){
                    player[1]=h;
                    player[0]=g;
                    Debug.Log("player3 "+player[1]);
                    Debug.Log("player2 "+player[0]);
                }
            }else if(g==player[2]){
                player[2]=g;
                Debug.Log("player2 "+player[2]);
                if(h==player[1]){
                    player[1]=h;
                    player[0]=f;
                    Debug.Log("player3 "+player[1]);
                    Debug.Log("player1 "+player[0]);
                }else if(f==player[1]){
                    player[0]=h;
                    player[1]=f;
                    Debug.Log("player1 "+player[1]);
                    Debug.Log("player3 "+player[0]);
                }
            }else if(h==player[2]){
                player[2]=h;
                Debug.Log("player3 "+player[2]);
                if(f==player[1]){
                    player[1]=f;
                    player[0]=g;
                    Debug.Log("player1 "+player[1]);
                    Debug.Log("player2 "+player[0]);
                }else if(g==player[1]){
                    player[1]=g;
                    player[0]=f;
                    Debug.Log("player2 "+player[1]);
                    Debug.Log("player1 "+player[0]);
                }
            }
        }else if(f==player[3]){
            player[3]=f;
            Debug.Log("player1 "+player[3]);
            if(g==player[2]){
                player[2]=g;
                Debug.Log("player2 "+player[2]);
                if(h==player[1]){
                    player[1]=h;
                    player[0]=e;
                    Debug.Log("player3 "+player[1]);
                    Debug.Log("player0 "+player[0]);
                }else if(e==player[1]){
                    player[1]=e;
                    player[0]=h;
                    Debug.Log("player0 "+player[1]);
                    Debug.Log("player3 "+player[0]);
                }
            }else if(h==player[2]){
                player[2]=h;
                Debug.Log("player3 "+player[2]);
                if(e==player[1]){
                    player[1]=e;
                    player[0]=g;
                    Debug.Log("player0 "+player[1]);
                    Debug.Log("player2 "+player[0]);
                }else if(g==player[1]){
                    player[0]=e;
                    player[1]=g;
                    Debug.Log("player2 "+player[1]);
                    Debug.Log("player0 "+player[0]);
                }
            }else if(e==player[2]){
                player[2]=e;
                Debug.Log("player0 "+player[2]);
                if(g==player[1]){
                    player[1]=g;
                    player[0]=h;
                    Debug.Log("player2 "+player[1]);
                    Debug.Log("player3 "+player[0]);
                }else if(h==player[1]){
                    player[1]=h;
                    player[0]=g;
                    Debug.Log("player3 "+player[1]);
                    Debug.Log("player2 "+player[0]);
                }
            }
        }else if(g==player[3]){
            player[3]=g;
            Debug.Log("player2 "+player[3]);
            if(f==player[2]){
                player[2]=f;
                Debug.Log("player1 "+player[2]);
                if(e==player[1]){
                    player[1]=e;
                    player[0]=h;
                    Debug.Log("player0 "+player[1]);
                    Debug.Log("player3 "+player[0]);
                }else if(h==player[1]){
                    player[0]=e;
                    player[1]=h;
                    Debug.Log("player3 "+player[1]);
                    Debug.Log("player0 "+player[0]);
                }
            }else if(e==player[2]){
                player[2]=e;
                Debug.Log("player0 "+player[2]);
                if(h==player[1]){
                    player[1]=h;
                    player[0]=f;
                    Debug.Log("player3 "+player[1]);
                    Debug.Log("player1 "+player[0]);
                }else if(f==player[1]){
                    player[0]=h;
                    player[1]=f;
                    Debug.Log("player1 "+player[1]);
                    Debug.Log("player3 "+player[0]);
                }
            }else if(h==player[2]){
                player[2]=h;
                Debug.Log("player3 "+player[2]);
                if(f==player[1]){
                    player[1]=f;
                    player[0]=e;
                    Debug.Log("player1 "+player[1]);
                    Debug.Log("player0 "+player[0]);
                }else if(e==player[1]){
                    player[1]=e;
                    player[0]=f;
                    Debug.Log("player0 "+player[1]);
                    Debug.Log("player1 "+player[0]);
                }
            }
        }else if(h==player[3]){
            player[3]=h;
            Debug.Log("player3 "+player[3]);
            if(e==player[2]){
                player[2]=e;
                Debug.Log("player0 "+player[2]);
                if(g==player[1]){
                    player[1]=g;
                    player[0]=f;
                    Debug.Log("player2 "+player[1]);
                    Debug.Log("player1 "+player[0]);
                }else if(f==player[1]){
                    player[0]=g;
                    player[1]=f;
                    Debug.Log("player1 "+player[1]);
                    Debug.Log("player2 "+player[0]);
                }
            }else if(f==player[2]){
                player[2]=f;
                Debug.Log("player1 "+player[2]);
                if(g==player[1]){
                    player[1]=g;
                    player[0]=e;
                    Debug.Log("player2 "+player[1]);
                    Debug.Log("player0 "+player[0]);
                }else if(e==player[1]){
                    player[0]=g;
                    player[1]=e;
                    Debug.Log("player0 "+player[1]);
                    Debug.Log("player2 "+player[0]);
                }
            }else if(g==player[2]){
                player[2]=g;
                Debug.Log("player2 "+player[2]);
                if(f==player[1]){
                    player[1]=f;
                    player[0]=e;
                    Debug.Log("player1 "+player[1]);
                    Debug.Log("player0 "+player[0]);
                }else if(e==player[1]){
                    player[1]=e;
                    player[0]=f;
                    Debug.Log("player0 "+player[1]);
                    Debug.Log("player1 "+player[0]);
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


