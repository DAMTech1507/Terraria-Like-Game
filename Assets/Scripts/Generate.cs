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
    
    public Tilemap TileMap;

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
 
 
            for (int j = 0; j < stonespace; j++)
            {
                TileMap.SetTile(Vector3Int.FloorToInt(new Vector3(w, j)), Stone);
            }
 
            for (int j = stonespace; j < distance; j++)
            {
                TileMap.SetTile(Vector3Int.FloorToInt(new Vector3(w, j)), Dirt);
            }
            TileMap.SetTile(Vector3Int.FloorToInt(new Vector3(w, distance)), Grass);
        }
    }
}