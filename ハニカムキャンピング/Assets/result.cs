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
        int[] targetArray = new int[4]{26, 400, 19, 504};

        // コンソールに配列の中身を表示します。
        

        // 処理回数を保持する変数です。
        int iterationNum = 0;

        // バブルソートで配列の中身を昇順で並べ替えます。
        for (int i = 0; i < targetArray.Length; i++){

            // 要素の比較を行います。最後の要素は外側のループが終了するごとに確定します。
            for (int j = 1; j < targetArray.Length - i; j++){
                // 処理回数の値を増やします。
                iterationNum++;
                
                // 隣り合う要素と比較し、順序が逆であれば入れ替えます。
                if (targetArray[j] < targetArray[j - 1]){

                    // 配列の要素の交換を行います。
                    int temp = targetArray[j];
                    targetArray[j] = targetArray[j - 1];
                    targetArray[j - 1] = temp;
                }
            }

            // コンソールに配列の中身を表示します。
            
        }
        
        // コンソールに配列の中身を表示します。
        Debug.Log(targetArray[0]);
        Debug.Log(targetArray[1]);
        Debug.Log(targetArray[2]);
        Debug.Log(targetArray[3]);
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
        ExecuteSort();
        }
    }
}

