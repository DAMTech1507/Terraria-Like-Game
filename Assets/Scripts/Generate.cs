using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Generate : MonoBehaviour
{
 
    public int width;
    public int height;
    public int distance;
    public int space;
 
    public Tile Grass;
    public Tile Dirt;
    public Tile Stone;
    public Tile Diamond;
    public Tile Coal;
    public Tile Log;
    public Tile Tree;

    public Tilemap FrontMap;
    public Tilemap BGMap;

    public float heightpoint;
    public float heightpoint2;
 
 
    // Use this for initialization
    void Start()
    {
        Generation();
    }
 
    void Generation()
    {
        distance = height;
        for (int w = 0; w < width; w++)
        {
            int lowernum = distance - 1;
            int heighernum = distance + 2;
            distance = Random.Range(lowernum, heighernum);
            space = Random.Range(12, 20);
            int stonespace = distance - space;
            int randomAmount = Random.Range(1, 50);
            for (int j = 0; j < stonespace; j++)
            {
                randomAmount = Random.Range(1, 500);
                if(randomAmount <= 25 && randomAmount > 1){
                    FrontMap.SetTile(Vector3Int.FloorToInt(new Vector3(w, j)), Coal);continue;
                }
                
                else{
                    if(randomAmount == 1){
                        FrontMap.SetTile(Vector3Int.FloorToInt(new Vector3(w, j)), Diamond); continue;
                    }
                    FrontMap.SetTile(Vector3Int.FloorToInt(new Vector3(w, j)), Stone);
                }
            }
 
            for (int j = stonespace; j < distance; j++)
            {
                FrontMap.SetTile(Vector3Int.FloorToInt(new Vector3(w, j)), Dirt);
            }
            if(randomAmount <= 20){
                FrontMap.SetTile(Vector3Int.FloorToInt(new Vector3(w, distance + 1)), Tree);
            }
            FrontMap.SetTile(Vector3Int.FloorToInt(new Vector3(w, distance)), Grass);
        }
    }
}