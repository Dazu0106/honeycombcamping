using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOver : MonoBehaviour
{
    public Renderer rend;

    void start(){
        rend = GetComponent<Renderer>();
    }

    public void OnMouseEnter(){
        Debug.Log("MouseEnter " + rend.name);
        rend.material.color = new Color32(242, 242, 242, 200);
    }

    public void OnMouseExit(){
        Debug.Log("MouseExit " + rend.name);
        rend.material.color = Color.white;
    }

}
