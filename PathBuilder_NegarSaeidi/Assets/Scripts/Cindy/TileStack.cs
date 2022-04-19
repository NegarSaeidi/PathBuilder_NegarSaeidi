using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileStack : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject tileStackParent;
    public static List<GameObject> TilesStack;
    private float YPlacement;
    public Material checkedTIle;
    private void Start()
    {
        TilesStack = new List<GameObject>();
        YPlacement = 0;
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Red") && (other.gameObject.GetComponent<MeshRenderer>().materials[1].color != checkedTIle.color) )
        {
            other.gameObject.GetComponent<MeshRenderer>().materials[1].color = checkedTIle.color;
            TileStackGeneration();
        }
    }

     private void TileStackGeneration()
     {
        var tile = Instantiate(tilePrefab, tileStackParent.transform,true);
        tile.transform.position = new Vector3(tileStackParent.transform.position.x, tileStackParent.transform.position.y + YPlacement, tileStackParent.transform.position.z);
        YPlacement += 0.2f;
        TilesStack.Add(tile);

     }
}
