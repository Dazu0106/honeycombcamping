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
          
          hitPos = Vector3Int.RoundToInt(collision.bounds.ClosestPoint(this.transform.position));//当たり判定の最も近い座標を取得してVectorIntに変換

          tilemap.SetTileFlags(hitPos, TileFlags.None);//タイルのフラグをtrueに

          //tilemap.SetColor(hitPos, new Color(1f, 1f, 1f,1f));

          tilemap.SetColor( hitPos, Color.yellow );
          print( tilemap.GetColor( hitPos ) );

          print( tilemap.GetTile( hitPos ) );

          //Debug.Log("当たった");
          print(hitPos);
           

           
    }
 
   


}
