using UnityEngine;
using System.Collections;

public class HexPlacer : MonoBehaviour
{
    public HexSnap hexSnap;
    public HexTile hexTilePrefab;
    private TileManager tileManager;
    
    void Awake(){
        hexSnap = GetComponent<HexSnap>();
        tileManager = GetComponent<TileManager>();
    }

    void Update(){
        if (Input.GetMouseButtonDown(0)){
            CheckLayer();
        }
    }
    
    private void CheckLayer(){
        Vector3 hexCoordinates = hexSnap.WorldToHex(GetComponent<MouseVectors>().MouseToGround().point);
        Vector3 worldCoordinates = hexSnap.HexToWorld(hexCoordinates);
        if( GetComponent<MouseVectors>().MouseToGround().collider.gameObject.layer == LayerMask.NameToLayer("Navigable")) { 
            CreateTile(worldCoordinates, (int)hexCoordinates.x, (int)hexCoordinates.z, 1);
        }
    }

    private void CreateTile(Vector3 position, int x , int z, int layer){
        HexTile newHexTile = Instantiate(hexTilePrefab) as HexTile;
        newHexTile.x = x;  newHexTile.z = z; newHexTile.layer = layer;
        newHexTile.transform.parent = transform;
        newHexTile.transform.localPosition = position;
        tileManager.tileList.Add(newHexTile);
    } 
}



