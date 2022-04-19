using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIleGeneration : MonoBehaviour
{
    public GameObject[] TilePrefabs;
    public static List<GameObject> GridTiles;
    public GameObject tilesParent;
    public int gridSize;
    void Start()
    {
        GridTiles = new List<GameObject>();
        GenerateTiles();
    }

  private void GenerateTiles()
    {
        int z = 0;
        int x = 0;
        for (int i = 0; i < gridSize; i++)
        {
            if ((i % 16) == 0)
            {
                z += 2;
                x = 0;
            }
            int rand = Random.Range(0, 2);
            var DefaultTile = TilePrefabs[rand];
            var tile = Instantiate(DefaultTile, new Vector3(x * 2, 0, z), Quaternion.identity);
   
         
            x++;
            tile.gameObject.transform.SetParent(tilesParent.gameObject.transform);
            GridTiles.Add(tile);
           

        }
    }
  
}
