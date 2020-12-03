using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class result : MonoBehaviour
{
    // Start is called before the first frame update
    
   
    // 二つのKeyValuePair<string, int>を比較するためのメソッド
    static int CompareKeyValuePair(KeyValuePair<string, int> x, KeyValuePair<string, int> y)
    {
        // Keyで比較した結果を返す
        return string.Compare(x.Key, y.Key);
    }


    void Start(){
        /*Player<string,int> dictionary=new Player<string,int>();
        
        player["player1"]=12;
        player["player2"]=3;
        player["player3"]=5;
        player["player4"]=4;*/
         // ソート対象のDictionary<string, int>
    var dict = new Dictionary<string, int>();

    dict.Add("Bob", 3);
    dict.Add("Dave", 1);
    dict.Add("Alice", 2);
    dict.Add("Charlie", 5);
    dict.Add("Eve", 4);

    // Dictionaryの内容をコピーして、List<KeyValuePair<string, int>>に変換
    var pairs = new List<KeyValuePair<string, int>>(dict);

    // List.Sortメソッドを使ってソート
    // (引数に比較方法を定義したメソッドを指定する)
    pairs.Sort(CompareKeyValuePair);

    
    }

    /*void ExecuteSort(){
        // ソートしたい配列を定義します。
        
        int[] targetArray = new int[4]{26, 40, 19, 50};
        int[] player;
        player=new int[4];
        player[0]=26;
        player[1]=40;
        player[2]=19;
        player[3]=50;
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

        if(a==player[0]){
            player[0]=a;
            if(b==player[1]){
                player[1]=b;
                if(c==player[2]){
                    player[2]=c;
                    player[3]=d;
                }else if(d==player[2]){
                    player[3]=c;
                    player[2]=d;
                }
            }else if(c==player[1]){
                player[1]=c;
                if(d==player[2]){
                    player[2]=d;
                    player[3]=b;
                }else if(b==player[2]){
                    player[3]=d;
                    player[2]=b;
                }
            }else if(d==player[1]){
                player[1]=d;
                if(b==player[2]){
                    player[2]=b;
                    player[3]=c;
                }else if(c==player[2]){
                    player[2]=c;
                    player[3]=b;
                }
            }
        }else if(b==player[0]){
            player[0]=b;
            if(c==player[1]){
                player[1]=c;
                if(d==player[2]){
                    player[2]=d;
                    player[3]=a;
                }else if(a==player[2]){
                    player[2]=a;
                    player[3]=d;
                }
            }else if(d==player[1]){
                player[1]=d;
                if(a==player[2]){
                    player[2]=a;
                    player[3]=c;
                }else if(c==player[2]){
                    player[3]=a;
                    player[2]=c;
                }
            }else if(a==player[1]){
                player[1]=a;
                if(c==player[2]){
                    player[2]=c;
                    player[3]=d;
                }else if(d==player[2]){
                    player[2]=d;
                    player[3]=c;
                }
            }
        }else if(c==player[0]){
            player[0]=c;
            if(b==player[1]){
                player[1]=b;
                if(c==player[2]){
                    player[2]=c;
                    player[3]=d;
                }else if(d==player[2]){
                    player[3]=c;
                    player[2]=d;
                }
            }else if(c==player[1]){
                player[1]=c;
                if(d==player[2]){
                    player[2]=d;
                    player[3]=b;
                }else if(b==player[2]){
                    player[3]=d;
                    player[2]=b;
                }
            }else if(d==player[1]){
                player[1]=d;
                if(b==player[2]){
                    player[2]=b;
                    player[3]=c;
                }else if(c==player[2]){
                    player[2]=c;
                    player[3]=b;
                }
            }
        }else if(a==player[0]){
            player[0]=a;
            if(b==player[1]){
                player[1]=b;
                if(c==player[2]){
                    player[2]=c;
                    player[3]=d;
                }else if(d==player[2]){
                    player[3]=c;
                    player[2]=d;
                }
            }else if(c==player[1]){
                player[1]=c;
                if(d==player[2]){
                    player[2]=d;
                    player[3]=b;
                }else if(b==player[2]){
                    player[3]=d;
                    player[2]=b;
                }
            }else if(d==player[1]){
                player[1]=d;
                if(b==player[2]){
                    player[2]=b;
                    player[3]=c;
                }else if(c==player[2]){
                    player[2]=c;
                    player[3]=b;
                }
            }
        }

        Debug.Log(player[3]);
        Debug.Log(player[2]);
        Debug.Log(player[1]);
        Debug.Log(player[0]);
    }*/


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
        Debug.Log("{0} {1}",pair.Key,pair.Value);
        //ExecuteSort();//
        }
        

    }
}

