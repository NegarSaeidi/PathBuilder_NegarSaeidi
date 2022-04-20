using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTIlesCount : MonoBehaviour
{
   
    public GameObject timer;
    public GameObject tilePrefab;
    public GameObject tileParent;
    private float ZPlacement;
    public GameObject loseDoor;
    private void OnTriggerEnter(Collider other)
    {
       
        timer.SetActive(false);
     
        BuildBridge();

    }

    private void BuildBridge()
    {
        for(int i=0; i< TileStack.TilesStack.Count; i++)
        {
            var tile = Instantiate(tilePrefab, tileParent.transform, true);
            tile.transform.position = new Vector3(tileParent.transform.position.x, tileParent.transform.position.y, tileParent.transform.position.z-ZPlacement);
            Destroy(TileStack.TilesStack[i]);
          

            ZPlacement += 2f;
        }
        var loseCheckBox = Instantiate(loseDoor, tileParent.transform, true);
        loseCheckBox.transform.position = new Vector3(tileParent.transform.position.x, tileParent.transform.position.y, tileParent.transform.position.z - ZPlacement);
    }
}
