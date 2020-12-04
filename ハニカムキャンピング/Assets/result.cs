using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class result : MonoBehaviour
{
    // Start is called before the first frame update
    
   
    


    void Start(){

    }

    void ExecuteSort(){
        // ソートしたい配列を定義します。
        
        int[] targetArray = new int[4]{26, 40, 19, 50};
        int[] player;
        player=new int[4];
        player[0]=26;
        player[1]=40;
        player[2]=19;
        player[3]=50;

        int a=player[0];
        int b=player[1];
        int c=player[2];
        int d=player[3];
        // コンソールに配列の中身を表示します。
        /*int[] geta;
        geta=new int[4];
        geta[0]=10000;
        geta[1]=20000;
        geta[2]=30000;
        geta[3]=40000;

        int[] player;
        player=new int[4];

        for(int k=0;k<4;k++){
            player[k]=(protoplayer[k]+geta[k]);
        }
        Debug.Log(player[3]);
        Debug.Log(player[2]);
        Debug.Log(player[1]);
        Debug.Log(player[0]);
        int a=player[0];
        int b=player[1];
        int c=player[2];
        int d=player[3];
        if(1==a/10000){
            player[0]=a-10000;
            if(2==b/10000){
                player[1]=b-20000;
                if(3==c/10000){
                    player[2]=c-30000;
                    player[3]=d-40000;
                }else if(4==c/10000){
                    player[3]=c-40000;
                    player[2]=d-30000;
                }
            }else if(3==b/10000){
                player[2]=b-30000;
                if(2==c/10000){
                    player[1]=c-20000;
                    player[3]=d-40000;
                }else if(4==c/10000){
                    player[3]=c-40000;
                    player[1]=d-20000;
                }
            }else if(4==b/10000){
                player[3]=b-40000;
                if(2==c/10000){
                    player[1]=c-20000;
                    player[2]=d-30000;
                }else if(3==c/10000){
                    player[3]=c-30000;
                    player[2]=d-20000;
                }
            }
        }else if(a/10000==2){
            player[1]=a-20000;
            if(b/10000==3){
                player[2]=b-30000;
                if(c/10000==4){
                    player[3]=c-40000;
                    player[0]=d-10000;
                }else if(c/10000==1){
                    player[0]=c-10000;
                    player[3]=d-40000;
                }
            }else if(b/10000==4){
                player[3]=b-40000;
                if(c/10000==1){
                    player[0]=c-10000;
                    player[2]=d-30000;
                }else if(c/10000==3){
                    player[2]=c-30000;
                    player[0]=d-10000;
                }
            }else if(b/10000==1){
                player[0]=b-10000;
                if(c/10000==4){
                    player[3]=c-40000;
                    player[2]=d-30000;
                }else if(c/10000==3){
                    player[2]=c-30000;
                    player[3]=d-40000;
                }
            }
        }else if(a/10000==3){
            player[2]=a-30000;
            if(b/10000==1){
                player[0]=b-10000;
                if(c/10000==2){
                    player[1]=c-20000;
                    player[3]=d-40000;
                }else if(c/10000==4){
                    player[3]=c-40000;
                    player[1]=d-20000;
                }
            }else if(b/10000==2){
                player[1]=b-20000;
                if(c/10000==1){
                    player[0]=c-10000;
                    player[3]=d-40000;
                }else if(c/10000==4){
                    player[3]=c-40000;
                    player[0]=d-10000;
                }
            }else if(b/10000==4){
                player[3]=b-40000;
                if(c/10000==2){
                    player[1]=c-20000;
                    player[0]=d-10000;
                }else if(c/10000==1){
                    player[0]=c-10000;
                    player[1]=d-20000;
                }
            }
        }else if(a/10000==4){
            player[3]=a-40000;
            if(b/10000==1){
                player[0]=b-10000;
                if(c/10000==3){
                    player[2]=c-30000;
                    player[1]=d-20000;
                }else if(c/10000==2){
                    player[1]=c-20000;
                    player[2]=d-30000;
                }
            }else if(b/10000==2){
                player[1]=b-20000;
                if(c/10000==1){
                    player[0]=c-10000;
                    player[2]=d-30000;
                }else if(c/10000==3){
                    player[2]=c-30000;
                    player[0]=d-10000;
                }
            }else if(b/10000==3){
                player[2]=b-30000;
                if(c/10000==2){
                    player[1]=c-20000;
                    player[0]=d-10000;
                }else if(c/10000==1){
                    player[0]=c-10000;
                    player[1]=d-20000;
                }
            }
        }*/
        // 処理回数を保持する変数です。
        int iterationNum = 0;

        // バブルソートで配列の中身を昇順で並べ替えます。
        for (int i = 0; i < player.Length; i++){

            // 要素の比較を行います。最後の要素は外側のループが終了するごとに確定します。
            for (int j = 1; j < player.Length - i; j++){
                // 処理回数の値を増やします。
                iterationNum++;
                
                // 隣り合う要素と比較し、順序が逆であれば入れ替えます。
                if (player[j] < player[j - 1]){

                    // 配列の要素の交換を行います。
                    int temp = player[j];
                    player[j] = player[j - 1];
                    player[j - 1] = temp;
                }
            }

            // コンソールに配列の中身を表示します。
            
        }
        
        int e=a;
        int f=b;
        int g=c;
        int h=d; 
        
        if(e==player[0]){
            player[0]=e;
            Debug.Log(player[0]);
            if(f==player[1]){
                player[1]=f;
                Debug.Log(player[1]);
                if(g==player[2]){
                    player[2]=g;
                    player[3]=h;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }else if(h==player[2]){
                    player[3]=h;
                    player[2]=g;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }
            }else if(g==player[1]){
                player[1]=g;
                Debug.Log(player[1]);
                if(d==player[2]){
                    player[2]=h;
                    player[3]=f;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }else if(f==player[2]){
                    player[3]=h;
                    player[2]=f;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }
            }else if(h==player[1]){
                player[1]=h;
                Debug.Log(player[1]);
                if(f==player[2]){
                    player[2]=f;
                    player[3]=g;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }else if(g==player[2]){
                    player[2]=g;
                    player[3]=f;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }
            }
        }else if(f==player[0]){
            player[0]=f;
            Debug.Log(player[0]);
            if(g==player[1]){
                player[1]=g;
                Debug.Log(player[1]);
                if(h==player[2]){
                    player[2]=h;
                    player[3]=e;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }else if(e==player[2]){
                    player[2]=e;
                    player[3]=h;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }
            }else if(h==player[1]){
                player[1]=h;
                Debug.Log(player[1]);
                if(e==player[2]){
                    player[2]=e;
                    player[3]=g;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }else if(g==player[2]){
                    player[3]=e;
                    player[2]=g;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }
            }else if(e==player[1]){
                player[1]=e;
                Debug.Log(player[1]);
                if(g==player[2]){
                    player[2]=g;
                    player[3]=h;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }else if(h==player[2]){
                    player[2]=h;
                    player[3]=g;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }
            }
        }else if(g==player[0]){
            player[0]=g;
            Debug.Log(player[0]);
            if(f==player[1]){
                player[1]=f;
                Debug.Log(player[1]);
                if(e==player[2]){
                    player[2]=e;
                    player[3]=h;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }else if(h==player[2]){
                    player[3]=e;
                    player[2]=h;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }
            }else if(e==player[1]){
                player[1]=e;
                Debug.Log(player[1]);
                if(h==player[2]){
                    player[2]=h;
                    player[3]=f;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }else if(f==player[2]){
                    player[3]=h;
                    player[2]=f;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }
            }else if(h==player[1]){
                player[1]=h;
                Debug.Log(player[1]);
                if(f==player[2]){
                    player[2]=f;
                    player[3]=e;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }else if(e==player[2]){
                    player[2]=e;
                    player[3]=f;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }
            }
        }else if(h==player[0]){
            player[0]=h;
            Debug.Log(player[0]);
            if(e==player[1]){
                player[1]=e;
                Debug.Log(player[1]);
                if(g==player[2]){
                    player[2]=g;
                    player[3]=f;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }else if(f==player[2]){
                    player[3]=g;
                    player[2]=f;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }
            }else if(f==player[1]){
                player[1]=f;
                Debug.Log(player[1]);
                if(g==player[2]){
                    player[2]=g;
                    player[3]=e;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }else if(e==player[2]){
                    player[3]=g;
                    player[2]=e;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }
            }else if(g==player[1]){
                player[1]=g;
                Debug.Log(player[1]);
                if(f==player[2]){
                    player[2]=f;
                    player[3]=e;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }else if(e==player[2]){
                    player[2]=e;
                    player[3]=f;
                    Debug.Log(player[2]);
                    Debug.Log(player[3]);
                }
            }
        }

        Debug.Log(player[3]);
        Debug.Log(player[2]);
        Debug.Log(player[1]);
        Debug.Log(player[0]);
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
        ExecuteSort();
        }
        

    }
}

