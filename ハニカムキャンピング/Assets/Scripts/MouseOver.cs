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
    }

    public void OnMouseExit(){
        Debug.Log("OnMouseExit " + rend.name);
    }

}
