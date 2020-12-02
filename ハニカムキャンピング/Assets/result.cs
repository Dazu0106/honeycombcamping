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
        
        /*int[] targetArray = new int[4]{26, 40, 19, 50};*/
        int[] protoplayer;
        protoplayer=new int[4];
        protoplayer[0]=26;
        protoplayer[1]=40;
        protoplayer[2]=19;
        protoplayer[3]=50;
        // コンソールに配列の中身を表示します。
        int[] geta;
        geta=new int[4];
        geta[0]=10000;
        geta[1]=20000;
        geta[2]=30000;
        geta[3]=40000;

        int[] player;
        player=new int[4];

        for(int h=0;h<4;h++){
            player[h]=(protoplayer[h]+geta[h]);
        }

        int a=player[0];
        int b=player[1];
        int c=player[2];
        int d=player[3];
        if(a/10000=1){
            player[0]=a-10000;
            if(b/10000=2){
                player[1]=b-20000;
                if(c/10000=3){
                    player[2]=c-30000;
                    player[3]=d-40000;
                }else if(c/10000=4){
                    player[3]=c-40000;
                    player[2]=d-30000;
                }
            }else if(b/10000=3){
                player[2]=b-30000;
                if(c/10000=2){
                    player[1]=c-20000;
                    player[3]=d-40000;
                }else if(c/10000=4){
                    player[3]=c-40000;
                    player[1]=d-20000;
                }
            }else if(b/10000=4){
                player[3]=b-40000;
                if(c/10000=2){
                    player[1]=c-20000;
                    player[2]=d-30000;
                }else if(c/10000=3){
                    player[3]=c-30000;
                    player[2]=d-20000;
                }
            }
        }else if(a/10000=2){
            player[1]=a-20000;
            if(b/10000=3){
                player[2]=b-30000;
                if(c/10000=4){
                    player[3]=c-40000;
                    player[0]=d-10000;
                }else if(c/10000=1){
                    player[0]=c-10000;
                    player[3]=d-40000;
                }
            }else if(b/10000=4){
                player[3]=b-40000;
                if(c/10000=1){
                    player[0]=c-10000;
                    player[2]=d-30000;
                }else if(c/10000=3){
                    player[2]=c-30000;
                    player[0]=d-10000;
                }
            }else if(b/10000=1){
                player[0]=b-10000;
                if(c/10000=4){
                    player[3]=c-40000;
                    player[2]=d-30000;
                }else if(c/10000=3){
                    player[2]=c-30000;
                    player[3]=d-40000;
                }
            }
        }else if(a/10000=3){
            player[2]=a-30000;
            if(b/10000=1){
                player[0]=b-10000;
                if(c/10000=2){
                    player[1]=c-20000;
                    player[3]=d-40000;
                }else if(c/10000=4){
                    player[3]=c-40000;
                    player[1]=d-20000;
                }
            }else if(b/10000=2){
                player[1]=b-20000;
                if(c/10000=1){
                    player[0]=c-10000;
                    player[3]=d-40000;
                }else if(c/10000=4){
                    player[3]=c-40000;
                    player[0]=d-10000;
                }
            }else if(b/10000=4){
                player[3]=b-40000;
                if(c/10000=2){
                    player[1]=c-20000;
                    player[0]=d-10000;
                }else if(c/10000=1){
                    player[0]=c-10000;
                    player[1]=d-20000;
                }
            }
        }else(a/10000=4){
            player[3]=a-40000;
            if(b/10000=1){
                player[0]=b-10000;
                if(c/10000=3){
                    player[2]=c-30000;
                    player[1]=d-20000;
                }else if(c/10000=2){
                    player[1]=c-20000;
                    player[2]=d-30000;
                }
            }else if(b/10000=2){
                player[1]=b-20000;
                if(c/10000=1){
                    player[0]=c-10000;
                    player[2]=d-30000;
                }else if(c/10000=3){
                    player[2]=c-30000;
                    player[0]=d-10000;
                }
            }else if(b/10000=3){
                player[2]=b-30000;
                if(c/10000=2){
                    player[1]=c-20000;
                    player[0]=d-10000;
                }else if(c/10000=1){
                    player[0]=c-10000;
                    player[1]=d-20000;
                }
            }
        }
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
        
        Debug.Log(player[0]);
        Debug.Log(player[1]);
        Debug.Log(player[2]);
        Debug.Log(player[3]);
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
        ExecuteSort();
        }
        

    }
}

