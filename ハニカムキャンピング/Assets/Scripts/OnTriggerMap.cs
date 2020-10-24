using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OnTriggerMap : MonoBehaviour
{
  
     // Start is called before the first frame update
    void Start()
    {
 
    }
 
    // Update is called once per frame
    void Update()
    {
 
    }

     private void OnTriggerEnter2D(Collider2D collision)

    {   
        var tilemap = GetComponent<Tilemap>();
        var hitPos = new Vector3Int(0,0,0);
        // 物体がトリガーに接触しとき、１度だけ呼ばれる
         if(collision.CompareTag("Player"))
          
          hitPos = Vector3Int.CeilToInt(collision.bounds.ClosestPoint(this.transform.position));
          tilemap.SetTileFlags(hitPos, TileFlags.None);
          tilemap.SetColor(hitPos, new Color(0.66f, 0.66f, 0.66f,0.66f));
          //tilemap.SetColor( hitPos, Color.red );
          print( tilemap.GetColor( hitPos ) );
          print( tilemap.GetTile( hitPos ) );

          //Debug.Log("当たった");
          print(hitPos);
           

           
    }
 
   


}
