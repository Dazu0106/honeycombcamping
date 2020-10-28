using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class UpButton : MonoBehaviour
{
    //内容を変更するテキスト変数
    public Text returnText;
    //時間カウント用変数
    float TimeCount = 3f;
 
    // Start is called before the first frame update
    void Start()
    {
        returnText.text = "初期状態です";
    }
 
    // Update is called once per frame
    void Update()
    {
        //時間を計測
        TimeCount -= Time.deltaTime;
 
        if (TimeCount <= 0)
        {
            returnText.text = "初期状態です";
        }
    }
 
    //ボタンが押されたときの処理
    public void ChangeText(){
        returnText.text = "ボタンが押されました！(3秒後に戻ります)";
        TimeCount = 3f;
    }
}