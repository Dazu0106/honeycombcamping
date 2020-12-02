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
        
        
        // コンソールに配列の中身を表示します。
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

