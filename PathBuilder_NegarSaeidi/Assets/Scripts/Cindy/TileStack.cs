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
    public static bool TimeIsUp;
    private void Start()
    {
        TimeIsUp = false;
        TilesStack = new List<GameObject>();
        YPlacement = 0;
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Red") && (other.gameObject.GetComponent<MeshRenderer>().materials[1].color != checkedTIle.color) && !TimeIsUp )
        {
            other.gameObject.GetComponent<AudioSource>().Play();
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
