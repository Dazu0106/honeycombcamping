using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActControllerManager : MonoBehaviour
{
    GameObject up_R, mid_R, down_R;
    GameObject up_L, mid_L, down_L;

    GameObject clickedButton;
    Vector2 Actclicked;

    // Start is called before the first frame update
    void Start()
    {
        up_R = GameObject.Find("Right up");
        mid_R = GameObject.Find("Right middle");
        down_R = GameObject.Find("Right down");

        up_L = GameObject.Find("Left up");
        mid_L = GameObject.Find("Left middle");
        down_L = GameObject.Find("Left down");

        Actclicked = new Vector2(1.3f, 1.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            clickedButton = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
 
            if (hit2d) {
                clickedButton = hit2d.transform.gameObject;
                //hit2d.transform.localScale = Actclicked;
            } 
 
            if(clickedButton == up_R){
                Debug.Log("Moved right up");
            }
            
            if(clickedButton == mid_R){
                Debug.Log("Moved right middle");
            }

            if(clickedButton == down_R){
                Debug.Log("Moved right down");
            }

            if(clickedButton == up_L){
                Debug.Log("Moved left up");
            }

            if(clickedButton == mid_L){
                Debug.Log("Moved left middle");
            }

            if(clickedButton == down_L){
                Debug.Log("Moved left down");
            }

        }
    }
}
