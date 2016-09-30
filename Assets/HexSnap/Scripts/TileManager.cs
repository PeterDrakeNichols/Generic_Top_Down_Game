using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileManager : MonoBehaviour {
     
    public List<HexTile> cluster = new List<HexTile>();
    public List<HexTile> tileList = new List<HexTile>();
    int[,,] directions = new int[2, 6, 2] {{{ 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, -1 }, { -1, 0 }, { -1, 1}},
                                           {{ 1, 1 }, { 1, 0 }, { 1, -1 }, { 0, -1 }, { -1, 0 }, { 0, 1 } }};
    public void AccessTileCluster()
    {
        RaycastHit hit = GetComponent<MouseVectors>().MouseToGround();
        if(hit.collider.tag == ("Bamboo")) 
        {
            cluster.Clear();
            HexTile accessedTile = hit.transform.gameObject.GetComponent<HexTile>();
            cluster.Add(accessedTile);
            accessedTile.visited = true;
            FindConnectedTiles(accessedTile);
            ClearVisitedFlags();
        }
    }

    public void FindConnectedTiles(HexTile accessedTile)
    {
       
        List<HexTile> neighbors = GetNeighbors(tileList, accessedTile.x, accessedTile.z);
        for(int i = 0; i < neighbors.Count; i++)
        {
            if (neighbors[i].visited)
            {
                continue;
            }
            neighbors[i].visited = true;
            cluster.Add(neighbors[i]);
            FindConnectedTiles(neighbors[i]);
        }
    }
    
    public void ClearVisitedFlags()
    {
        foreach(HexTile hexTile in tileList)
        {
            hexTile.visited = false;
        }
    }

    public List<HexTile> GetNeighbors(List<HexTile> tileList, int x, int z)
    {
        List<HexTile> neighbors = new List<HexTile>();
        for(int i = 0; i < tileList.Count; i++)
        {
            if (AreNeighbors(x, z, tileList[i].x, tileList[i].z))
            {
              neighbors.Add(tileList[i]);
            }
        }
        return neighbors;      
    }

    public bool AreNeighbors(int x1, int z1, int x2, int z2)
    {

        int[] difference = new int[2] { x2 - x1, z2 - z1 };
        for (int i = 0; i < 6; i++)
        {
            int[] direction = new int[2] { directions[z1 & 1, i, 0], directions[z1 & 1, i, 1] };
            if (difference[0] == direction[0] && difference[1] == direction[1])
            {
                return true;
            }
        }
        return false;
    }
}
