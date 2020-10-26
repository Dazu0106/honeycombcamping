using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class MovementController : MonoBehaviour
{
    //Stores input from the PlayerInput
    public Vector2 movementInput;
    public Vector3 direction;
    public Tilemap TileColor;

    bool hasMoved;

    void Awake()
    {
        UpdatePosition();
    }
    // Update is called once per frame
    void Update()
    {
        if(movementInput.x == 0)
        {
            hasMoved = false;
        }
        else if(movementInput.x != 0 && !hasMoved)
        {
            hasMoved = true;

            GetMovementDirection();
        }
    }

    public void GetMovementDirection()
    {
        if(movementInput.x < 0)
        {
            if(movementInput.y > 0)
            {
                direction = new Vector3(-0.5f,0.5f);
            }

            else if(movementInput.y < 0)
            {
                direction = new Vector3(-0.5f,-0.5f);
            }
            else
            {
                direction = new Vector3(-1,0,0);
            }
            transform.position += direction;
            UpdatePosition();
        }

        else if(movementInput.x > 0)
        {
            if(movementInput.y > 0)
            {
                direction = new Vector3(0.5f,0.5f);
            }
            else if(movementInput.y < 0)
            {
                direction = new Vector3(0.5f,-0.5f);
            }
            else
            {
                direction = new Vector3(1,0,0);
            }
            transform.position += direction;
            UpdatePosition();
        }
    }

    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }
    public void UpdatePosition()
    {   var tilemap = GetComponent<Tilemap>();
        Vector3Int currentPlayerTile = TileColor.WorldToCell(transform.position);
        TileColor.SetTileFlags(currentPlayerTile, TileFlags.None);//タイルのフラグをtrueに
        TileColor.SetColor( currentPlayerTile, Color.red );
         

         
         

          
    }

    
    
}
