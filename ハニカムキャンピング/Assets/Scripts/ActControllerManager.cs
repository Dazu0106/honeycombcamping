using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActControllerManager : MonoBehaviour
{
    GameObject up_R, mid_R, down_R;
    GameObject up_L, mid_L, down_L;
    
    GameObject clickedButton;
    GameObject player;

    public Vector3 direction;


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
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            clickedButton = null;

            // ClickedSprites check
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
 
            if (hit2d) {
                clickedButton = hit2d.transform.gameObject;
            } 
 
            // 右上
            if(clickedButton == up_R){
                Debug.Log("Moved right up");
                direction = new Vector3(0.4f,0.6f);
                player.GetComponent<MovementController>().transform.position += direction;
                player.GetComponent<MovementController>().UpdatePosition();
            }
            
            // 右
            if(clickedButton == mid_R){
                Debug.Log("Moved right middle");
                direction = new Vector3(0.8f,0,0);
                player.GetComponent<MovementController>().transform.position += direction;
                player.GetComponent<MovementController>().UpdatePosition();
            }

            // 右下
            if(clickedButton == down_R){
                Debug.Log("Moved right down");
                direction = new Vector3(0.4f,-0.6f);
                player.GetComponent<MovementController>().transform.position += direction;
                player.GetComponent<MovementController>().UpdatePosition();
            }

            // 左上
            if(clickedButton == up_L){
                Debug.Log("Moved left up");
                direction = new Vector3(-0.4f,0.6f);
                player.GetComponent<MovementController>().transform.position += direction;
                player.GetComponent<MovementController>().UpdatePosition();
            }

            // 左
            if(clickedButton == mid_L){
                Debug.Log("Moved left middle");
                direction = new Vector3(-0.8f,0,0);
                player.GetComponent<MovementController>().transform.position += direction;
                player.GetComponent<MovementController>().UpdatePosition();
            }

            // 左下
            if(clickedButton == down_L){
                Debug.Log("Moved left down");
                direction = new Vector3(-0.4f,-0.6f);
                player.GetComponent<MovementController>().transform.position += direction;
                player.GetComponent<MovementController>().UpdatePosition();
            }

        }
    }
}

// ボタンクリックをInputSystemに紐づける方法がわからない → 直接directionを指定してやって動かしてみる? 
// MovementControllerを継承すると Debug.Logが働かなくなる? (そもそもif文が動いてない可能性あり)

// MonoBehaviourを継承したMovementControllerであるから動くんじゃないかわからん